using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.CompanyValidation
{
   public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyByIdRequest>
    {
        public UpdateCompanyValidator()
        {
            this.RuleFor(x => x.Type).NotEmpty().IsInEnum().WithMessage("Wybierz Pralnia lub Hotel");
            this.RuleFor(x => x.Name).NotEmpty().MaximumLength(250).WithMessage("Pole {PropertyName} nie może być puste");
            this.RuleFor(x => x.TaxNumber).NotEmpty().WithMessage("Podaj NIP.").Length(12).WithMessage("Format NIP'u to 111-111-1111");
            this.RuleFor(x => x.Street).NotEmpty().MaximumLength(50).WithMessage("Pole {PropertyName} nie może być puste");
            this.RuleFor(x => x.Number).NotEmpty().MaximumLength(10).WithMessage("Pole {PropertyName} nie może być puste");
            this.RuleFor(x => x.ZipCode).NotEmpty().Length(6).WithMessage("Pole {PropertyName} nie może być puste");
            this.RuleFor(x => x.City).NotEmpty().MaximumLength(100).WithMessage("Pole {PropertyName} nie może być puste");
        }
    }
}
