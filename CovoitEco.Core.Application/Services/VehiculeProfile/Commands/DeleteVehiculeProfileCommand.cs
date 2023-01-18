using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovoitEco.Core.Application.Common.Exceptions;
using CovoitEco.Core.Application.Common.Interfaces;
using MediatR;

namespace CovoitEco.Core.Application.Services.VehiculeProfile.Commands
{
    public class DeleteVehiculeProfileCommand : IRequest
    {
        public int VEH_Id;
    }
    public class DeleteVehiculeProfileCommandHandler : IRequestHandler<DeleteVehiculeProfileCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteVehiculeProfileCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteVehiculeProfileCommand request, CancellationToken cancellationToken)
        {
            var vehicule = await _context.Vehicule.FindAsync(request.VEH_Id);

            if (vehicule == null)
            {
                throw new NotFoundException(nameof(vehicule), request.VEH_Id);
            }

            _context.Vehicule.Remove(vehicule);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
