using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CovoitEco.Core.Application.Services.VehiculeProfile.Commands
{
    public class CreateVehiculeProfileCommandValidator : AbstractValidator<CreateVehiculeProfileCommand>
    {
        public CreateVehiculeProfileCommandValidator()
        {
            RuleFor(item => item.VEH_Immatriculation).NotNull()
                .MaximumLength(20)
                .NotNull()
                .WithMessage("Maximum Length equals 20");
            RuleFor(item => item.VEH_Couleur).NotNull()
                .MaximumLength(20)
                .NotNull()
                .WithMessage("Maximum Length equals 20");
            RuleFor(item => item.VEH_Marque).NotNull()
                .MaximumLength(20)
                .NotNull()
                .WithMessage("Maximum Length equals 20");
            RuleFor(item => item.VEH_Modele).NotNull()
                .MaximumLength(20)
                .NotNull()
                .WithMessage("Maximum Length equals 20");
            //RuleFor(item => item.VEH_Courant).Equals(false);
            //RuleFor(item => item.VEH_Disponible).Equals(true); // change to false after the demonstration
            RuleFor(item => item.VEH_UTL_Id).NotNull().WithMessage("Not null");
            RuleFor(item => item.VEH_NombrePlace).InclusiveBetween(1,8).NotNull().WithMessage("Between 1 and 8"); // seat driver not include 
            RuleFor(item => item.VEH_NormeEuro).InclusiveBetween(0,7).NotNull().WithMessage("Between 0 and 7");
        }

    }
}
