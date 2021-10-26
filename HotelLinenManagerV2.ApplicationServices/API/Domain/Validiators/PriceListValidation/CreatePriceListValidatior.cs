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
            this.RuleFor(x => x.CompanyId)
              .GreaterThanOrEqualTo(0).WithMessage("ID Bielizny nie może być ujemne!")
              .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.Name)
                .NotEmpty().NotNull().WithMessage("Pole {PropertyName} nie może być puste");
            this.RuleFor(x => x.Number)
                .NotEmpty().NotNull().WithMessage("Pole {PropertyName} nie może być puste");
            this.RuleFor(x => x.CreationDate)
               .NotEmpty().NotNull().WithMessage("Pole {PropertyName} nie może być puste");
        }
    }
}
