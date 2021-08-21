using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServices;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServices
{
    public class GetAllLaundryRequest : RequestBase,IRequest<GetAllLaundryResponse>
    {
        public int? Number { get; set; }
    }
}
