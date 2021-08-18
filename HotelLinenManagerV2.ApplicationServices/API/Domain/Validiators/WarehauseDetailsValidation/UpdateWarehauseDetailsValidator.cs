using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.WarehauseDetails;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.WarehauseDetailsValidation
{
    class UpdateWarehauseDetailsValidator : AbstractValidator<UpdateDetailsRequest>
    {
        public UpdateWarehauseDetailsValidator()
        {
            this.RuleFor(x => x.WarehauseId).NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.Id).NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!")
                .GreaterThanOrEqualTo(0).WithMessage("ID nie może być ujemne!");
            this.RuleFor(x => x.HotelLinenId).NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.Amount).GreaterThanOrEqualTo(0).WithMessage("Ilość bielizny nie może być ujemna!")
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
        }
    }
}
