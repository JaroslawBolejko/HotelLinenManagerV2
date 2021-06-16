using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Companies;
using HotelLinenManagerV2.DataAccess.Entities;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.CompanyValidation
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyRequest>
    {
        //public CreateCompanyValidator()
        //{
        //    this.RuleFor(x => x.Type).NotEmpty().IsInEnum().WithMessage("Wybierz Pralnia lub Hotel");
        //    this.RuleFor(x=>x.Name).NotEmpty().MaximumLength(250).WithMessage("Pole {PropertyName} nie może być puste");
        //    this.RuleFor(x => x.TaxNumber).NotEmpty().WithMessage("Podaj NIP.").MaximumLength(12).WithMessage("Format NIP nie jest własciwy!");
        //    this.RuleFor(x => x.Street).NotEmpty().MaximumLength(50).WithMessage("Pole {PropertyName} nie może być puste");
        //    this.RuleFor(x => x.Number).NotEmpty().MaximumLength(10).WithMessage("Pole {PropertyName} nie może być puste");
        //    //this.RuleFor(x => x.ApartmentNumber).GreaterThan(0);
        //    this.RuleFor(x => x.ZipCode).NotEmpty().Length(6).WithMessage("Pole {PropertyName} nie może być puste");
        //    this.RuleFor(x => x.City).NotEmpty().MaximumLength(100).WithMessage("Pole {PropertyName} nie może być puste");

        //}
    }
}
