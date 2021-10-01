using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.HotelLinenValidation
{
    public class CreateHotelLinenValidator : AbstractValidator<CreateHotelLinenRequest>
    {
        public CreateHotelLinenValidator()
        {
           
            this.RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Podaj nazwę z krótkim opisem.")
                .MaximumLength(100);
            this.RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Ilość nie może być mniejsza od 0!")
                .NotNull().WithMessage("Podaj ilość bieliny.");
            this.RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.Size)
                .NotEmpty().MaximumLength(80).WithMessage("Pole {PropertyName} nie może być puste");
            this.RuleFor(x => x.Weight)
                .NotEmpty().NotNull().WithMessage("Pole {PropertyName} nie może być równe 0");
            this.RuleFor(x => x.PricePerKg)
                .NotEmpty().NotNull().WithMessage("Pole {PropertyName} nie może być równe 0");
            this.RuleFor(x => x.TypeName)
                .IsInEnum().WithMessage("Niewłaściwy typ magazynu. Wybierz z listy dostępnych!");


        }
    }
}
