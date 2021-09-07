using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinenTypes;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinenTypes
{
    public class DeleteLinenTypeByIdRequest : RequestBase, IRequest<DeleteLinenTypeByIdResponse>
    {
        public int Id { get; set; }
    }
}
