using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.WarehauseDetails;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.WarehauseDetails
{
    public class GetDetailsByIdRequest : RequestBase,IRequest<GetDetailsByIdResponse>
    {
        public int Id { get; set; }
    }
}
