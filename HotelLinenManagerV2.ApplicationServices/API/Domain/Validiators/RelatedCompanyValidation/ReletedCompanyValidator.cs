using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.RelatedCompanies;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.RelatedCompanyValidation
{
    public class ReletedCompanyValidator : AbstractValidator<CreateRelatedCompanyRequest>
    {
        public ReletedCompanyValidator()
        {
            this.RuleFor(x => x.CompanyId)
               .GreaterThanOrEqualTo(0).WithMessage("Id nie może być ujuemne");
            this.RuleFor(x => x.LaundryId)
               .GreaterThanOrEqualTo(0).WithMessage("Id nie może być ujuemne");
        }
    }
}
