using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CovoitEco.Core.Application.Services.Reservation.Queries
{
    public class GetAllReservationUserProfileQuery : IRequest<ReservationUserProfileVm>
    {
        public int UTL_Id { get; set; }
    }
    public class GetAllReservationUserProfileQueryHandler : IRequestHandler<GetAllReservationUserProfileQuery, ReservationUserProfileVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public GetAllReservationUserProfileQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReservationUserProfileVm> Handle(GetAllReservationUserProfileQuery request, CancellationToken cancellationToken)
        {
            
            var list = await (
                from r in _context.Reservation
                join f in _context.Facture on r.RES_Id equals f.FACT_RES_Id
                join sr in _context.StatutReservation on r.RES_STATRES_Id equals sr.STATRES_Id
                join a in _context.Annonce on r.RES_ANN_Id equals a.ANN_Id
                join u in _context.Utilisateur on a.ANN_UTL_Id equals u.UTL_Id
                join v in _context.Vehicule on a.ANN_UTL_Id equals v.VEH_UTL_Id
                join sa in _context.StatutAnnonce on a.ANN_STATANN_Id equals sa.STATANN_Id
                where r.RES_UTL_Id == request.UTL_Id
                orderby r.RES_Id
                select new ReservationUserProfileDTO()
                {
                    RES_Id = r.RES_Id,
                    RES_DateReservation = r.RES_DateReservation,
                    RES_ANN_Id = r.RES_ANN_Id,
                    RES_FACT_StatutLibelle = sr.STATRES_Libelle,
                    RES_FACT_FactureResolus = f.FACT_Resolus,
                    RES_ANN_Prix = a.ANN_Prix,
                    RES_ANN_LocaliteDepart = a.ANN_LocaliteDepart,
                    RES_ANN_LocaliteArrive = a.ANN_LocaliteArrive,
                    RES_ANN_DateDepart = a.ANN_DateDepart,
                    RES_ANN_DateArrive = a.ANN_DateArrive,
                    RES_ANN_StatutLibelle = sa.STATANN_Libelle,
                    RES_ANN_OptAutoroute = a.ANN_OptAutoroute,
                    RES_ANN_OptFumeur = a.ANN_OptFumeur,
                    RES_ANN_OptAnimaux = a.ANN_OptAnimaux,
                    RES_ANN_AnnonceurNom = u.UTL_Nom,
                    RES_ANN_AnnonceurPrenom = u.UTL_Prenom,
                    RES_ANN_VEH_VehImmatriculation = v.VEH_Immatriculation
                }
            ).Distinct().ToListAsync(cancellationToken);

            var result = RemoveDuplicates(list);

            return new ReservationUserProfileVm()
            {
                Lists = result
            };
        }
        /// <summary>
        /// To delete if find a best solution 
        /// </summary>
        /// <param name="listWithDuplicate"></param>
        /// <returns></returns>
        public List<ReservationUserProfileDTO> RemoveDuplicates(List<ReservationUserProfileDTO> listWithDuplicate)
        {
            int id = 0;
            List<ReservationUserProfileDTO> listWithoutDubplicate = new List<ReservationUserProfileDTO>();

            foreach (var item in listWithDuplicate)
            {
                if (item.RES_Id != id)
                    listWithoutDubplicate.Add(item);
                id = item.RES_Id;
            }
            return listWithoutDubplicate;
        }
    }
}

