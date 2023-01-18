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

namespace CovoitEco.Core.Application.Services.Annonce.Queries
{
    public class GetAllAnnonceProfileQuery : IRequest<AnnonceProfileVm>
    {
        public int UTL_Id { get; set; }
    }
    public class GetAllAnnonceProfileQueryHandler : IRequestHandler<GetAllAnnonceProfileQuery, AnnonceProfileVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public GetAllAnnonceProfileQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AnnonceProfileVm> Handle(GetAllAnnonceProfileQuery request, CancellationToken cancellationToken)
        {
            return new AnnonceProfileVm()
            {
                Lists = await (
                    from a in _context.Annonce
                    join s in _context.StatutAnnonce on a.ANN_STATANN_Id equals s.STATANN_Id
                    join u in _context.Utilisateur on a.ANN_UTL_Id equals u.UTL_Id
                    join v in _context.Vehicule on a.ANN_VEH_Id equals v.VEH_Id
                    where u.UTL_Id == request.UTL_Id
                    select new AnnonceProfileDTO()
                    {
                        ANNPR_Id = a.ANN_Id,
                        ANNPR_DatePublication = a.ANN_DatePublication,
                        ANNPR_Prix = a.ANN_Prix,
                        ANNPR_LocaliteDepart = a.ANN_LocaliteDepart,
                        ANNPR_LocaliteArrive = a.ANN_LocaliteArrive,
                        ANNPR_DateDepart = a.ANN_DateDepart,
                        ANNPR_DateArrive = a.ANN_DateArrive,
                        ANNPR_Statut = s.STATANN_Libelle,
                        ANN_OptAutoroute = a.ANN_OptAutoroute,
                        ANN_OptFumeur = a.ANN_OptFumeur,
                        ANN_OptAnimaux = a.ANN_OptAnimaux,
                        ANNPR_AnnonceurNom = u.UTL_Nom,
                        ANNPR_AnnonceurPrenom = u.UTL_Prenom,
                        ANNPR_VehImmatriculation = v.VEH_Immatriculation
                    }
                ).ToListAsync(cancellationToken)
            };
        }
    }
}
