using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServiceDetails;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.WarehauseDetailsValidation
{
    class UpdateLaundryDetailsValidator : AbstractValidator<UpdateLaundryDetailsRequest>
    {
        public UpdateLaundryDetailsValidator()
        {
            this.RuleFor(x => x.HotelLinenId).NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.Amount).GreaterThanOrEqualTo(0).WithMessage("Ilość bielizny nie może być ujemna!")
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
        }
    }
}
