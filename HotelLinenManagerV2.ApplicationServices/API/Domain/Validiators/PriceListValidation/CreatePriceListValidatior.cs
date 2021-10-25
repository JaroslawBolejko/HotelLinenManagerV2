using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceLists;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.PriceListValidation
{
    public class CreatePriceListValidatior : AbstractValidator<CreatePriceListRequest>
    {
        public CreatePriceListValidatior()
        {
            this.RuleFor(x => x.LaundryId)
                .GreaterThanOrEqualTo(0).WithMessage("ID Bielizny nie może być ujemne!")
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.PricePerKg)
                .NotEmpty().NotNull().WithMessage("Pole {PropertyName} nie może być puste")
                .GreaterThan(0).WithMessage("Pole {PropertyName} nie może być mniejsze lub równe 0");
            this.RuleFor(x => x.TaxValue)
                .NotEmpty().NotNull().WithMessage("Pole {PropertyName} nie może być puste")
                .GreaterThan(0).WithMessage("Pole {PropertyName} nie może być mniejsze lub równe 0");
        }
    }
}
