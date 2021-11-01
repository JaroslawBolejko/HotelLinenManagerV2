using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.RelatedCompanies;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.RelatedCompanies
{
    public class GetAllRelatedCompaniesRequest : RequestBase,IRequest<GetAllRelatedCompaniesResponse>
    {
        public int? LaundryId { get; set; }
    }
}
