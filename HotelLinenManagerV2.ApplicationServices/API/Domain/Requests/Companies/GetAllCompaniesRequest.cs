using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Companies;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Companies
{
    public class GetAllCompaniesRequest : IRequest<GetAllCompaniesResponse>
    {
        public string Name { get; set; }
        public string TaxNumber { get; set; }
    }
}
