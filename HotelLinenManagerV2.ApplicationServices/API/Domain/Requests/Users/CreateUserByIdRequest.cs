using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Users;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Users
{
    public class CreateUserByIdRequest : IRequest<CreateUserByIdResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string CompanyId { get; set; }
        public string Permission { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
