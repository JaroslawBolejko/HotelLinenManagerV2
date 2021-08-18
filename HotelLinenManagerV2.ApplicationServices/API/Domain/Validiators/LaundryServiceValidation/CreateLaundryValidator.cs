using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServices;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.LaundryServiceValidation
{
    public class CreateLaundryValidator : AbstractValidator<CreateLaundryRequest>
    {
        public CreateLaundryValidator()
        {
            this.RuleFor(x => x.CompanyId)
                .GreaterThanOrEqualTo(0).WithMessage("Ilość bielizny nie może być ujemna!")
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.Number)
                .GreaterThanOrEqualTo(0).WithMessage("Ilość bielizny nie może być ujemna!")
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x=>x.RecievedDate)
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x=>x.IssuedDate)
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
        }
    }
}
