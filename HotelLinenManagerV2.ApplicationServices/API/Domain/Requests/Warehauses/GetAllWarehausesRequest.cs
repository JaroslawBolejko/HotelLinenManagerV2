using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Warehauses;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Warehauses
{
    public class GetAllWarehausesRequest : RequestBase, IRequest<GetAllWarehausesResponse>
    {
        public int? WarehauseNumber { get; set; }
        public byte? WarehauseType { get; set; }
    }
}
