using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Warehauses;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.WarehauseValidation
{
    public class CreateWarehauseValidator : AbstractValidator<CreateWarehauseRequest>
    {
        public CreateWarehauseValidator()
        {
            this.RuleFor(x => x.WarehauseType).IsInEnum().WithMessage("Niewłaściwy typ magazynu. Wybierz z listy dostępnych!");
            this.RuleFor(x => x.Name).NotEmpty().MaximumLength(100).WithMessage("Pole {PropertyName} nie może być puste");
            this.RuleFor(x => x.WarehauseNumber).GreaterThan(0).WithMessage("Numer magazybu nie może być ujemny")
                .LessThan(10000).WithMessage("Podany numer jest zbyt duży");
            this.RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
        }
    }
}
