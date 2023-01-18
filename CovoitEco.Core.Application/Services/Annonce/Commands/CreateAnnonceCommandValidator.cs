using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CovoitEco.Core.Application.Services.Annonce.Commands
{
    public class CreateAnnonceCommandValidator : AbstractValidator<CreateAnnonceCommand>
    {
        public CreateAnnonceCommandValidator()
        {
            RuleFor(item => item.ANN_DateDepart).LessThan(item=>item.ANN_DateArrive).NotNull().WithMessage("Not null"); // no tested
            RuleFor(item => item.ANN_DateArrive).NotNull().WithMessage("Not null");
            RuleFor(item => item.ANN_OptAnimaux).NotNull().WithMessage("Not null");
            RuleFor(item => item.ANN_OptAutoroute).NotNull().WithMessage("Not null");
            RuleFor(item => item.ANN_OptFumeur).NotNull().WithMessage("Not null");
            RuleFor(item => item.ANN_UTL_Id).NotNull().WithMessage("Not null");
            RuleFor(item => item.ANN_VEH_Id).NotNull().WithMessage("Not null");
            RuleFor(item => item.ANN_NumeroDepart).MaximumLength(5).WithMessage("Not null");
            RuleFor(item => item.ANN_NumeroArrive).MaximumLength(5).WithMessage("Not null");
            RuleFor(item => item.ANN_VilleDepart).MaximumLength(20).WithMessage("Not null");
            RuleFor(item => item.ANN_VilleArrive).MaximumLength(20).WithMessage("Not null");
            RuleFor(item => item.ANN_RueDepart).MaximumLength(20).WithMessage("Not null");
            RuleFor(item => item.ANN_RueArrive).MaximumLength(20).WithMessage("Not null");
            RuleFor(item => item.ANN_CodePostalDepart).MaximumLength(10).WithMessage("Not null");
            RuleFor(item => item.ANN_CodePostalArrive).MaximumLength(10).WithMessage("Not null");
        }
    }
}
