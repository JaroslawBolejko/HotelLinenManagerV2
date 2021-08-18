using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServiceDetails;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.LaundryServiceDetailsValidation
{
    class UpdateLaundryDetailsValidator : AbstractValidator<UpdateLaundryDetailsRequest>
    {
        public UpdateLaundryDetailsValidator()
        {
            this.RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0).WithMessage("ID bielizny nie może być ujemne!")
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.HotelLinenId)
                .GreaterThanOrEqualTo(0).WithMessage("ID bielizny nie może być ujemne!")
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.LaundryServiceId)
                .GreaterThanOrEqualTo(0).WithMessage("ID usługi nie może być ujemne!")
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.Amount)
                .GreaterThanOrEqualTo(0).WithMessage("Ilość bielizny nie może być ujemna!")
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
        }
    }
}
