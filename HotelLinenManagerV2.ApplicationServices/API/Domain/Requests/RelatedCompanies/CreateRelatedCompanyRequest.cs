using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.RelatedCompanies;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.RelatedCompanies
{
    public class CreateRelatedCompanyRequest : RequestBase,IRequest<CreateRelatedCompanyResponse>
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int LaundryId { get; set; }
    }
}
