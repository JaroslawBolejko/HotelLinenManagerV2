using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.WarehauseDetails;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.WarehauseDetails
{
    public class GetAllDetailsRequest : RequestBase,IRequest<GetAllDetailsResponse>
    {
        public int? WarehauseId { get; set; }
        public int? HotelLinenId { get; set; }

    }
}
