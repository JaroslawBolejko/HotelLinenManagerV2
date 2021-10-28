using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.RelatedCompanies;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.RelatedCompanies
{
    public class DeleteRelatedCompanyRequest : RequestBase, IRequest<DeleteRelatedCompanyResponse>
    {
        public int Id { get; set; }
    }
}
