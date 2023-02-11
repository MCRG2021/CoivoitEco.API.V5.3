using System.Data;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CovoitEco.Core.Application.Services.Reservation.Commands
{
    public class UpdateAccepterReservationCommand : IRequest<int>
    {
        public int RES_Id { get; set; }
        public class UpdateAccepterReservationCommandHandler : IRequestHandler<UpdateAccepterReservationCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public UpdateAccepterReservationCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateAccepterReservationCommand request, CancellationToken cancellationToken)
            {
                var reservation = await _context.Reservation.FindAsync(request.RES_Id);

                // Check if annonce status "Publier"
                var annonce = await _context.Annonce.Where(item =>
                    item.ANN_STATANN_Id == 1 && item.ANN_Id == reservation.RES_ANN_Id).ToListAsync();

                // Check if all place toked 
                var vehicule = _context.Vehicule.Where(item => item.VEH_Id == annonce.First().ANN_VEH_Id); // to get a number of place
                var reservationListValidated = _context.Reservation.Where(item => item.RES_ANN_Id == annonce.First().ANN_Id && item.RES_STATRES_Id != 4 && item.RES_STATRES_Id != 1); // to get all reservation validated
                var reservationListNValidated = _context.Reservation.Where(item => item.RES_ANN_Id == annonce.First().ANN_Id && item.RES_STATRES_Id == 1); // to get all reservation invalidated

                if (reservationListValidated.Count() >= vehicule.First().VEH_NombrePlace)
                    throw new Exception("All places toked");

                // Update
                if (!annonce.Equals(null))
                {
                    if (annonce.Count() > 0) reservation.RES_STATRES_Id = 2;
                    else throw new Exception("The reservation can't be accepted");
                }
                else throw new Exception("The reservation can't be accepted");

                // Canceled the other reservation 
                if (reservationListValidated.Count() + 1 >= vehicule.First().VEH_NombrePlace)
                {
                    foreach (var item in reservationListNValidated)
                    {
                        if (item.RES_STATRES_Id == 1) item.RES_STATRES_Id = 4;
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);

                return request.RES_Id;
            }
        }
    }
}
