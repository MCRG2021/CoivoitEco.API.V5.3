using FluentValidation;

namespace CovoitEco.Core.Application.Services.Reservation.Commands
{
    public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationCommandValidator()
        {
            RuleFor(item => item.RES_UTL_Id).GreaterThanOrEqualTo(1).WithMessage("Not null or GreaterThanOrEqualTo 1");
            RuleFor(item => item.RES_ANN_Id).GreaterThanOrEqualTo(1).WithMessage("Not null or GreaterThanOrEqualTo 1");
        }
    }
}
