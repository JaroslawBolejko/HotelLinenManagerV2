using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServiceDetails;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServiceDetails
{
    public class GetAllLaundryDetailsRequest : RequestBase,IRequest<GetAllLaundryDetailsResponse>
    {
        public int? LaundryServiceId { get; set; }
    }
}
