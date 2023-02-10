using System.Data;
using System.Linq;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Application.DTOs;
using CovoitEco.Core.Application.ExtensionMethods;
using CovoitEco.Core.Application.Filter;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CovoitEco.Core.Application.Services.Reservation.Commands
{
    public class CreateReservationCommand : IRequest<int>
    {
        #region Properties

        public int RES_ANN_Id { get; set; }
        public int RES_UTL_Id { get; set; }

        #endregion
    }
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateReservationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            // Check identity user
            var user = await _context.Utilisateur.FindAsync(request.RES_UTL_Id);
            if (user.UTL_Mail != EmailAuthorizationCheck.email) throw new Exception("Bad user");

            // Test if user had a reservation (an "Annule" reservation don't count) 
            List<AnnonceReservationDTO> list = new List<AnnonceReservationDTO>();
            list = await (from r in _context.Reservation
                          where (r.RES_ANN_Id == request.RES_ANN_Id) && (r.RES_UTL_Id == request.RES_UTL_Id) && (r.RES_STATRES_Id != 4) 
                          select new AnnonceReservationDTO
                          {

                              ANNRES_Id = r.RES_ANN_Id,

                          }).ToListAsync(cancellationToken);

            if (list.Count != 0) throw new Exception("Er is already a reservation for this user on this annonce");

            // Test if too late
            var annonce = _context.Annonce.Where(item => item.ANN_Id == request.RES_ANN_Id);
            if (TooLate(annonce.First().ANN_DateDepart) == true) throw new Exception("It's too late to create your reservation");

            // Test if the owner is not a user
            if (annonce.First().ANN_UTL_Id == request.RES_UTL_Id)
                throw new Exception("A user and the owner are the same");

            // Test if I have enough places
            var listReservation = _context.Reservation.
                Where(item => item.RES_ANN_Id == request.RES_ANN_Id && (item.RES_STATRES_Id == 2 || item.RES_STATRES_Id == 3)); // 2 ("Confirme" or "EnOrdre")
            var vehicule = _context.Vehicule.Where(item => item.VEH_Id == annonce.First().ANN_VEH_Id);
            if (listReservation.Count() >= vehicule.First().VEH_NombrePlace) throw new Exception("Er is no free places");

            // Creation reservation
            var entity = new Domain.Entities.Reservation
            {
                RES_Id = 0, // auto increment 
                RES_DateReservation = DateTime.Now,
                RES_ANN_Id = request.RES_ANN_Id,
                RES_STATRES_Id = 1, // by default 
                RES_UTL_Id = request.RES_UTL_Id
            };

            //Test if had a overlap reservation
            var allAnnonce = _context.Annonce.Where(item => item.ANN_STATANN_Id != 3 && item.ANN_UTL_Id != user.UTL_Id);
            var annonceOverlap = OverlapControler.OverlapReservation(annonce.First(), allAnnonce.ToList());
            if (annonceOverlap.Count > 0)
            {
                foreach (var overlapItem in annonceOverlap)
                {
                  var reservationOverlap = _context.Reservation.Where(item => item.RES_ANN_Id == overlapItem.ANN_UTL_Id);
                  if (reservationOverlap != null) 
                      if(reservationOverlap.Count() > 0) throw new Exception("Reservation for annonce overlap");
                }
            }

            _context.Reservation.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.RES_Id;
        }
        private bool TooLate(DateTime dateTimeDepart)
        {
            double minutes = 0;
            if (dateTimeDepart.Date >= DateTime.Now.Date)
            {
                TimeSpan timespan = dateTimeDepart - DateTime.Now;
                minutes = timespan.TotalMinutes;
                if (minutes >= 15) return false;
            }
            return true;
        }
    }
}
