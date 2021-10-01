using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.WarehauseDetails;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.WarehauseDetails
{
    public class CreateDetailsRequest : RequestBase,IRequest<CreateDetailsResponse>
    {
        public int? HotelLinenId { get; set; }
        public int? WarehauseId { get; set; }
        public int Amount { get; set; }
    }
}
