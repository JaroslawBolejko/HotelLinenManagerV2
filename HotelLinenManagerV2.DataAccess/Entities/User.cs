using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class User : EntityBase
    {
        public enum Role
        {
            AdminHotel,
            UserHotel,
            UserLaundry

        }
        public enum Position
        {
            Employee,
            Manager,
            Owner
        }


        public int CompanyId { get; set; }
        public Company Company { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        public Position PositionType { get; set; }
       
        [Required]
        public Role Permission { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        public string Salt { get; set; }
    }
}
