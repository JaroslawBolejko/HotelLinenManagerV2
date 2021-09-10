using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinens;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens
{
    public class GetAllHotelLinenRequest : RequestBase, IRequest<GetAllHotelLinenResponse>
    {
        public string Description  { get; set; }
        public int? HotelLinenTypeId { get; set; }
        public int? WarehauseId { get; set; }
    }
}
