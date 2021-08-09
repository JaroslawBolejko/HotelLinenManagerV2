using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.WarehauseDetails;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.WarehauseDetails
{
    public class DeleteDetailsByIdRequest : RequestBase,IRequest<DeleteDetailsByIdResponse>
    {
        public int Id { get; set; }
    }
}
