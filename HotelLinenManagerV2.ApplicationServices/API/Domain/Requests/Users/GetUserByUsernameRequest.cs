using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Users;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Users
{
    public class GetUserByUsernameRequest : IRequest<GetUserByUsernameResponse>
    {
        public string Username { get; set; }
    }
}
