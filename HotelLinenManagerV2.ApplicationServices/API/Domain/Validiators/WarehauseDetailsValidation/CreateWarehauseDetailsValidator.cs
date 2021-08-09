using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.WarehauseDetails;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.WarehauseDetailsValidation
{
    public class CreateWarehauseDetailsValidator : AbstractValidator<CreateDetailsRequest>
    {
        public CreateWarehauseDetailsValidator()
        {
            this.RuleFor(x => x.WarehauseId).NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.HotelLinenId).NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.Amount).GreaterThanOrEqualTo(0).WithMessage("Ilość bielizny nie może być ujemna!")
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
        }
    }
}
