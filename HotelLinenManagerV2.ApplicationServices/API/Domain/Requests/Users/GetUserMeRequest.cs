using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Users;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Users
{
    public class GetUserMeRequest : RequestBase, IRequest<GetUserMeResponse>
    {
        public string Me { get; set; }
    }
}
