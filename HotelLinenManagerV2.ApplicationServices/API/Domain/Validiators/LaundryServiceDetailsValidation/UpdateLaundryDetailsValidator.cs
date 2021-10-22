using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServiceDetails;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.LaundryServiceDetailsValidation
{
    class UpdateLaundryDetailsValidator : AbstractValidator<UpdateLaundryDetailsRequest>
    {
        public UpdateLaundryDetailsValidator()
        {
            this.RuleFor(x => x.HotelLinenId)
                .GreaterThanOrEqualTo(0).WithMessage("ID bielizny nie może być ujemne!")
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            //this.RuleFor(x => x.LaundryServiceId)
            //    .GreaterThanOrEqualTo(0).WithMessage("ID usługi nie może być ujemne!")
            //    .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.Amount)
                .GreaterThanOrEqualTo(0).WithMessage("Ilość bielizny nie może być ujemna!")
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            //this.RuleFor(x => x.PricePerKg)
            // .GreaterThanOrEqualTo(0).WithMessage("Cena nie może być ujemna!")
            // .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            //this.RuleFor(x => x.TotalWeight)
            //  .GreaterThan(0).WithMessage("Waga nie może być ujemna lub równa 0!")
            //  .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            //this.RuleFor(x => x.TaxValue)
            //  .GreaterThanOrEqualTo(0).WithMessage("Stawka podatku VAT nie może być ujemna!")
            //  .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
        }
    }
}
