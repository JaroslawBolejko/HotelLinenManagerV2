using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Companies;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Companies
{
    public class DeleteCompanyByIdRequest : RequestBase, IRequest<DeleteCompanyByIdResponse>
    {
        public int Id { get; set; }
    }
}
