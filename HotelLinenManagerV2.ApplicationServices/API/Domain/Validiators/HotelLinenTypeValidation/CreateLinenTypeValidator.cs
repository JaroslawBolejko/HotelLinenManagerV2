using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinenTypes;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.HotelLinenTypeValidation
{
    public class CreateLinenTypeValidator : AbstractValidator<CreateLinenTypeRequest>
    {
        public CreateLinenTypeValidator()
        {
            this.RuleFor(x=>x.Size).NotEmpty().MaximumLength(80).WithMessage("Pole {PropertyName} nie może być puste");
            this.RuleFor(x => x.Weight).NotEmpty().NotNull().WithMessage("Pole {PropertyName} nie może być równe 0");
            this.RuleFor(x=>x.PricePerKg).NotEmpty().NotNull().WithMessage("Pole {PropertyName} nie może być równe 0");
            this.RuleFor(x=>x.Tax).NotEmpty().NotNull().WithMessage("Pole {PropertyName} nie może być równe 0");
            this.RuleFor(x=>x.TypeName).IsInEnum().WithMessage("Niewłaściwy typ magazynu. Wybierz z listy dostępnych!");
        }
    }
}
