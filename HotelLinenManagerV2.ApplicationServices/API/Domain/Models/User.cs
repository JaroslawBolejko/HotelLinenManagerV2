using static HotelLinenManagerV2.DataAccess.Entities.User;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CompanyId { get; set; }
        public Role Permission { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public Company Company { get; set; }
    }
}
