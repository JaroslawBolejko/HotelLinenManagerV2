using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServices;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.LaundryServiceValidation
{
    class UpdateLaundryValidator : AbstractValidator<UpdateLaundryByIdRequest>
    {
        public UpdateLaundryValidator()
        {
            this.RuleFor(x => x.CompanyId)
                .GreaterThanOrEqualTo(0).WithMessage("Id nie może być ujuemne!")
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.RecievedDate)
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.IssuedDate)
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.TotalBrutto)
               .GreaterThanOrEqualTo(0).WithMessage("Suma brutto nie może być ujuemna")
               .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.TotalNetto)
               .GreaterThanOrEqualTo(0).WithMessage("Suma netto nie może być ujuemna")
               .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.TotalTax)
               .GreaterThanOrEqualTo(0).WithMessage("Suma podatku nie może być ujuemna")
               .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.LaundryId)
               .GreaterThanOrEqualTo(0).WithMessage("Id nie może być ujuemne")
               .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
        }
    }
}
