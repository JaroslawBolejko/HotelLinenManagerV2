using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.WarehauseDetails;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.WarehauseDetailsValidation
{
    class UpdateWarehauseDetailsValidator : AbstractValidator<UpdateDetailsRequest>
    {
        public UpdateWarehauseDetailsValidator()
        {
            this.RuleFor(x => x.WarehauseId)
                .GreaterThan(0).WithMessage("Id Nie może być równe 0!")
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.HotelLinenId)
                .GreaterThan(0).WithMessage("Id Nie może być równe 0!")
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Ilość nie może być mniejsza od 0!")
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
        }
    }
}
