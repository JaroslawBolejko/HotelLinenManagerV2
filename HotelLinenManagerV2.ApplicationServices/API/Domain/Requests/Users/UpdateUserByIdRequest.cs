using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Users;
using MediatR;
using static HotelLinenManagerV2.DataAccess.Entities.User;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Users
{
    public class UpdateUserByIdRequest : RequestBase, IRequest<UpdateUserByIdResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CompanyId { get; set; }
        public Role Permission { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        public string PhotoPath { get; set; }

    }
}
