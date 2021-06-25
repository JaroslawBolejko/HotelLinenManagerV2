using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Warehauses;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Warehauses
{
    public class GetAllWarehausesRequest : RequestBase, IRequest<GetAllWarehausesResponse>
    {
        public int? WarehauseNumber { get; set; }

    }
}
