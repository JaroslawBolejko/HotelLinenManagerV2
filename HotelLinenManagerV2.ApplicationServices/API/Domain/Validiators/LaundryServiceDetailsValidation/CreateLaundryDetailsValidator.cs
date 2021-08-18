using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServiceDetails;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.LaundryServiceDetailsValidation
{
    public class CreateLaundryDetailsValidator : AbstractValidator<CreateLaundryDetailsRequest>
    {
        public CreateLaundryDetailsValidator()
        {
            this.RuleFor(x => x.HotelLinenId)
                .GreaterThanOrEqualTo(0).WithMessage("ID Bielizny nie może być ujemne!")
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
