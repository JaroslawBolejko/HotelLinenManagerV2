using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Companies;
using HotelLinenManagerV2.ApplicationServices.Components.Validation;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.CompanyValidation
{
    public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyByIdRequest>
    {
        private readonly IStartsWithDigit startsWithDigit;
        private readonly IZipCode zipCode;

        public UpdateCompanyValidator(IStartsWithDigit startsWithDigit, IZipCode zipCode)
        {
            this.startsWithDigit = startsWithDigit;
            this.zipCode = zipCode;

            this.RuleFor(x => x.Type).IsInEnum().WithMessage("Wybierz Pralnia lub Hotel");
            this.RuleFor(x => x.Name).MaximumLength(250).WithMessage("Wprowadzona liczba znaków w polu {PropertyName} jest za duża");
            this.RuleFor(x => x.TaxNumber).NotEmpty().WithMessage("Podaj NIP!")
                .MaximumLength(15).WithMessage("NIP składa się z 10 cyfr, bez znaków dodatkowych oraz oznaczeń kraju!");
            this.RuleFor(x => x.Street).MaximumLength(50).WithMessage("Wprowadzona liczba znaków w polu {PropertyName} jest za duża");
            this.RuleFor(x => x.Number).MaximumLength(10).WithMessage("Wprowadzona liczba znaków w polu {PropertyName} jest za duża");
            this.RuleFor(x => x.ApartmentNumber).Must(startsWithDigit.DigitStarter).WithMessage("Numer lokalu musi zawierać cyfre")
                .MaximumLength(10).WithMessage("Wprowadzona liczba znaków w polu {PropertyName} jest za duża");
            this.RuleFor(x => x.ZipCode).MaximumLength(6).WithMessage("Wprowadzona liczba znaków w polu {PropertyName} powinna wynosić 6")
                .Must(zipCode.IsPostalCode).WithMessage("zły format kodu!prawidłowy to xx-xxx, gdzie x - jest liczbą całkowitą.");
            this.RuleFor(x => x.City).MaximumLength(100).WithMessage("Wprowadzona liczba znaków w polu {PropertyName} jest za duża");
            
        }
              
    }
}
