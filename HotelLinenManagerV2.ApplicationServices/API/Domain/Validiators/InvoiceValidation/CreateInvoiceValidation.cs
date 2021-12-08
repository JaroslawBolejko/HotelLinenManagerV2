using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Invoices;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.InvoiceValidation
{
    public class CreateInvoiceValidation : AbstractValidator<CreateInvoiceRequest>
    {
        public CreateInvoiceValidation()
        {
            this.RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.DateOfInvoice)
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            //this.RuleFor(x => x.TotalCost)
            //   .GreaterThanOrEqualTo(0).WithMessage("Suma nie może być ujuemna")
            //   .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.CompanyId)
                .GreaterThanOrEqualTo(0).WithMessage("Id nie może być ujuemne")
                .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.LaundryId)
               .GreaterThanOrEqualTo(0).WithMessage("Id nie może być ujuemne")
               .NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
        }
    }
}
