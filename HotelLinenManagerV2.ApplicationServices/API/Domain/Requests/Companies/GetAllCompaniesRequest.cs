using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Companies;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Companies
{
    public class GetAllCompaniesRequest : RequestBase, IRequest<GetAllCompaniesResponse>
    {
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public int? CompanyId { get; set; }
    }
}
