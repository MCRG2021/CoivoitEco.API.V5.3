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

namespace CovoitEco.Core.Application.Services.VehiculeProfile.Queries
{
    public class GetVehiculeQuery : IRequest<VehiculeProfileVm>
    {
        public int ANN_Id { get; set; }
    }

    public class GetVehiculeQueryHandler : IRequestHandler<GetVehiculeQuery, VehiculeProfileVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public GetVehiculeQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VehiculeProfileVm> Handle(GetVehiculeQuery request,
            CancellationToken cancellationToken)
        {

            return new VehiculeProfileVm()
            {
                Lists = await (
                    from v in _context.Vehicule
                    join a in _context.Annonce on v.VEH_Id equals a.ANN_VEH_Id
                    where (a.ANN_Id == request.ANN_Id)
                    select new VehiculeProfileDTO()
                    {
                        VEHPR_Id = v.VEH_Id,
                        VEHPR_Immatriculation = v.VEH_Immatriculation,
                        VEHPR_Couleur = v.VEH_Couleur,
                        VEHPR_Marque = v.VEH_Marque,
                        VEHPR_Modele = v.VEH_Modele,
                        VEHPR_NombrePlace = v.VEH_NombrePlace,
                        VEHPR_NormeEuro = v.VEH_NormeEuro
                    }
                ).ToListAsync(cancellationToken)
            };

        }
    }
}