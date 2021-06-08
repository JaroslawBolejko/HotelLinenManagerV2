using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinens;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens
{
    public class GetAllHotelLinenRequest : IRequest<GetAllHotelLinenResponse>
    {
        public string NameWithShortDescription  { get; set; }
        public int? HotelLinenTypeId { get; set; }
    }
}
