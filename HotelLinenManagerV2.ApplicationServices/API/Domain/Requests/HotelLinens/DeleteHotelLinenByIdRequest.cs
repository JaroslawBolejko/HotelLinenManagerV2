using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinens;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens
{
    public class DeleteHotelLinenByIdRequest : IRequest<DeleteHotelLinenByIdResponse>
    {
        public int Id { get; set; }
    }
}
