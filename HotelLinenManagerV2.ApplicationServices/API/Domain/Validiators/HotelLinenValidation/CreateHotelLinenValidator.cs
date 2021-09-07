using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.HotelLinenValidation
{
    public class CreateHotelLinenValidator : AbstractValidator<CreateHotelLinenRequest>
    {
        public CreateHotelLinenValidator()
        {
            this.RuleFor(x => x.HotelLinenTypeId).NotEmpty().WithMessage("Bielizna musi posiadać typ!")
                .GreaterThan(0).WithMessage("Id nie może być równe zero");
            this.RuleFor(x => x.NameWithShortDescription).NotEmpty().WithMessage("Podaj nazwę z krótkim opisem.")
                .MaximumLength(100);
            this.RuleFor(x => x.Amount).NotNull().WithMessage("Podaj ilość bieliny.");
            this.RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");


        }
    }
}
