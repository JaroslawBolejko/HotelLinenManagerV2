using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Warehauses;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Warehauses
{
    public class GetWarehauseByIdRequest : IRequest<GetWarehauseByIdResponse>
    {
        public int WarehauseId { get; set; }
    }
}
