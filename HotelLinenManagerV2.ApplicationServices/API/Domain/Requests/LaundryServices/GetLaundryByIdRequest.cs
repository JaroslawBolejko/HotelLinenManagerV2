using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServices;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServices
{
    public class GetLaundryByIdRequest : RequestBase,IRequest<GetLaundryByIdResponse>
    {
        public int Id { get; set; }
    }
}
