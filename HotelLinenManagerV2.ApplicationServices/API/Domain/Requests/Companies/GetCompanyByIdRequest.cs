using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Companies;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Companies
{
    public class GetCompanyByIdRequest : RequestBase, IRequest<GetCompanyByIdResponse>
    {
        public int Id { get; set; }
    }
}
