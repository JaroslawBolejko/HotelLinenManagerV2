using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinenTypes;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinenTypes
{
    public class GetLinenTypeByIdRequest : RequestBase,IRequest<GetLinenTypeByIdResponse>
    {
        public int Id { get; set; }
    }
}
