using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServices;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServices
{
    public class GetAllLaundryRequest : RequestBase, IRequest<GetAllLaundryResponse>
    {
        public string Number { get; set; }
        //public int Skip { get; set; } = 0;
        //public int Take { get; set; } = 5;
    }
}
