using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.WarehauseDetails;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.WarehauseDetails
{
    public class UpdateDetailsRequest : RequestBase,IRequest<UpdateDetailsResponse>
    {
        public int Id { get; set; }
        public int HotelLinenId { get; set; }
        public int WarehauseId { get; set; }
        public ushort Amount { get; set; }
    }
}
