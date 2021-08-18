using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.HotelLinenValidation
{
    public class UpdatedHotelLinenValidator : AbstractValidator<UpdateHotelLinenByIdRequest>
    {
        public UpdatedHotelLinenValidator()
        {
            this.RuleFor(x => x.Id).NotEmpty().WithMessage("Pole nie może być puste")
                 .GreaterThan(0).WithMessage("Id nie może być równe zero");
            this.RuleFor(x => x.HotelLinenTypeId).NotEmpty().WithMessage("Bielizna musi posiadać typ!")
                 .GreaterThan(0).WithMessage("Id nie może być równe zero");
            this.RuleFor(x => x.NameWithShortDescription).NotEmpty().WithMessage("Podaj nazwę z krótkim opisem.")
                .MaximumLength(100);
            this.RuleFor(x => x.Amount).NotNull().WithMessage("Podaj ilość bieliny.");

        }
    }
}
