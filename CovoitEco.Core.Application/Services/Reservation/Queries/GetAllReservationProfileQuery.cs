﻿using AutoMapper;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Application.DTOs;
using CovoitEco.Core.Application.Filter;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CovoitEco.Core.Application.Services.Reservation.Queries
{
    public class GetAllReservationProfileQuery : IRequest<ReservationProfileVm>
    {
        public int ANN_Id { get; set; }
    }
    public class GetAllReservationProfileHandler : IRequestHandler<GetAllReservationProfileQuery, ReservationProfileVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public GetAllReservationProfileHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReservationProfileVm> Handle(GetAllReservationProfileQuery request, CancellationToken cancellationToken)
        {
            // Check itdenity user
            var annonce = _context.Annonce.Where(item => item.ANN_Id == request.ANN_Id);
            var user = _context.Utilisateur.Where(item => item.UTL_Id == annonce.First().ANN_UTL_Id);
            if (user.First().UTL_Mail != EmailAuthorizationCheck.email) throw new Exception("Bad user");

            return new ReservationProfileVm()
            {
                Lists = await (
                from r in _context.Reservation
                join f in _context.Facture on r.RES_Id equals f.FACT_RES_Id
                join sr in _context.StatutReservation on r.RES_STATRES_Id equals sr.STATRES_Id
                join u in _context.Utilisateur on r.RES_UTL_Id equals u.UTL_Id
                where r.RES_ANN_Id == request.ANN_Id && r.RES_STATRES_Id != 4 // 4 = reservation canceled
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
                ).ToListAsync(cancellationToken)
            };
        }
    }
}
