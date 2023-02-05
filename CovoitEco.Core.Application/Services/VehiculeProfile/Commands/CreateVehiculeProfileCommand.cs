using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Application.Filter;
using MediatR;

namespace CovoitEco.Core.Application.Services.VehiculeProfile.Commands
{
    public class CreateVehiculeProfileCommand : IRequest<int>
    {
        public string VEH_Immatriculation { get; set; }
        public string VEH_Couleur { get; set; }
        public string VEH_Marque { get; set; }
        public string VEH_Modele { get; set; }
        public int VEH_NombrePlace { get; set; }
        public int VEH_NormeEuro { get; set; }
        public int VEH_UTL_Id { get; set; }

    }
    public class CreateVehiculeProfileCommandHandler : IRequestHandler<CreateVehiculeProfileCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateVehiculeProfileCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateVehiculeProfileCommand request, CancellationToken cancellationToken)
        {
            // Check identity user
            var user = await _context.Utilisateur.FindAsync(request.VEH_UTL_Id);
            if (user.UTL_Mail != EmailAuthorizationCheck.email) throw new Exception("Bad user");

            var entity = new Domain.Entities.Vehicule
            {
                VEH_Id = 0, // auto increment 
                VEH_Immatriculation = request.VEH_Immatriculation,
                VEH_Couleur = request.VEH_Couleur,
                VEH_Courant = false, 
                VEH_Disponible = true, // true for the demonstration 
                VEH_Marque = request.VEH_Marque,
                VEH_Modele = request.VEH_Modele,
                VEH_NombrePlace = request.VEH_NombrePlace,
                VEH_NormeEuro = request.VEH_NormeEuro,
                VEH_UTL_Id = request.VEH_UTL_Id
            };

            _context.Vehicule.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.VEH_Id;

        }
    }
}
