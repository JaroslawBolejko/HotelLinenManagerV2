using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Users;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Users
{
    public class DeleteUserByIdRequest : IRequest<DeleteUserByIdResponse>
    {
        public int Id { get; set; }
    }
}
