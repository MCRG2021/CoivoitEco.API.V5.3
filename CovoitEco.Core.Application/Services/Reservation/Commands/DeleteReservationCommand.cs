using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Application.DTOs;
using CovoitEco.Core.Application.Services.Reservation.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CovoitEco.Core.Application.Services.Reservation.Commands
{
    public class DeleteReservationCommand : IRequest<int>
    {
        public int RES_Id { get; set; }
    }
    public class DeleteReservationCommandCommandHandler : IRequestHandler<DeleteReservationCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteReservationCommandCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _context.Reservation.FindAsync(request.RES_Id);

            // Check if reservation statut = "EnAttente"
            if (reservation.RES_STATRES_Id != 1) throw new Exception("You can not canceled a reservation already accepted");

            reservation.RES_STATRES_Id = 4;

            await _context.SaveChangesAsync(cancellationToken);

            return request.RES_Id;
        }
    }
}
