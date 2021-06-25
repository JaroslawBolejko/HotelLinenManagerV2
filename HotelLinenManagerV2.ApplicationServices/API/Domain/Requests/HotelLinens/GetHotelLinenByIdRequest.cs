using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinens;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens
{
    public class GetHotelLinenByIdRequest : RequestBase, IRequest<GetHotelLinenByIdResponse>
    {
        public int Id { get; set; }
    }
}
