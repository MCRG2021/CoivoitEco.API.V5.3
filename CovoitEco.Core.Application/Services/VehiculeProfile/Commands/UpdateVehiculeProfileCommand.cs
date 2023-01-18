using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovoitEco.Core.Application.Common.Exceptions;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Domain.Entities;
using MediatR;

namespace CovoitEco.Core.Application.Services.VehiculeProfile.Commands
{
    public class UpdateVehiculeProfileCommand : IRequest <int>
    {
        public int VEH_Id { get; set; }
        public bool VEH_Courant { get; set; }
        public bool VEH_Disponible { get; set; }
    }
    public class UpdateVehiculeProfileCommandHandler : IRequestHandler<UpdateVehiculeProfileCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateVehiculeProfileCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateVehiculeProfileCommand request, CancellationToken cancellationToken)
        {

            var vehicule = await _context.Vehicule.FindAsync(request.VEH_Id);

            if (vehicule == null)
            {
                throw new NotFoundException(nameof(Vehicule), request.VEH_Id);
            }

            vehicule.VEH_Courant = request.VEH_Courant;
            vehicule.VEH_Disponible = request.VEH_Disponible;

            await _context.SaveChangesAsync(cancellationToken);

            return vehicule.VEH_Id;
        }
    }
}
