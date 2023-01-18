using System.Linq;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Application.DTOs;
using CovoitEco.Core.Application.Services.Reservation.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CovoitEco.Core.Application.Services.Reservation.Commands
{
    public class UpdateConfirmePaymentCommand : IRequest<int>
    {
        public int RES_Id { get; set; }
    }

    public class UpdateConfirmePaymentCommandHandler : IRequestHandler<UpdateConfirmePaymentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateConfirmePaymentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateConfirmePaymentCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _context.Reservation.FindAsync(request.RES_Id);

            var annonce = await _context.Annonce.FindAsync(reservation.RES_ANN_Id);

            // State Facture verification 
            var facture = await (
                from r in _context.Reservation
                join f in _context.Facture on r.RES_Id equals f.FACT_RES_Id
                where r.RES_Id == request.RES_Id
                select new FactureInfo()
                {
                    resolus = f.FACT_Resolus
                }
            ).ToListAsync();


            // Statut "EnCours" + journey ended + reservation payed 
            if (annonce.ANN_STATANN_Id == 2 && annonce.ANN_DateArrive < DateTime.Now && facture[0].resolus == true)
            {
                reservation.RES_STATRES_Id = 3;

                await _context.SaveChangesAsync(cancellationToken);

                // "EnCours" => "Close"
                ReservationProfileVm listReservation = new ReservationProfileVm();
                int nbreReservStatClose = 0;

                // Get list reservation for this annonce
                listReservation.Lists = await (
                    from r in _context.Reservation
                    join f in _context.Facture on r.RES_Id equals f.FACT_RES_Id
                    join sr in _context.StatutReservation on r.RES_STATRES_Id equals sr.STATRES_Id
                    join u in _context.Utilisateur on r.RES_UTL_Id equals u.UTL_Id
                    where r.RES_ANN_Id == reservation.RES_ANN_Id
                    select new ReservationProfileDTO()
                    {
                        RESPR_Id = r.RES_Id,
                        RESPR_DateReservation = r.RES_DateReservation,
                        RESPR_ANN_Id = r.RES_ANN_Id,
                        RESPR_StatutLibelle = sr.STATRES_Libelle,
                        RESPR_FactureResolus = f.FACT_Resolus,
                        RESPR_Nom = u.UTL_Nom,
                        RESPR_Prenom = u.UTL_Prenom
                    }
                ).ToListAsync(cancellationToken);

                // svg number of reservation payed ("EnOrdre")
                foreach (var reservationList in listReservation.Lists)
                {
                    if (reservationList.RESPR_StatutLibelle == "EnOrdre")
                    {
                        nbreReservStatClose++;
                    }
                }

                // if all reservation payed 
                if (nbreReservStatClose == listReservation.Lists.Count) // to count current update
                {
                    annonce.ANN_STATANN_Id = 3; // = Close
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return request.RES_Id;
        }
    }

    public class FactureInfo
    {
        #region Properties

        public bool resolus { get; set; }

        #endregion
    }
}

