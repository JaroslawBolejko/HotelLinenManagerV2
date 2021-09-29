using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.WarehauseDetails;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.WarehauseDetailsValidation
{
    public class CreateWarehauseDetailsValidator : AbstractValidator<CreateDetailsRequest>
    {
        public CreateWarehauseDetailsValidator()
        {
            this.RuleFor(x => x.WarehauseId).GreaterThan(0).WithMessage("Id Nie może być równe 0!").NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.HotelLinenId).GreaterThan(0).WithMessage("Id Nie może być równe 0!").NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
        }
    }
}
