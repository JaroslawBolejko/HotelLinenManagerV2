using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public enum Role
    {
        AdminHotel = 0,
        UserHotel = 1,
        UserLaundry = 2

    }
    public enum PlaceOfWork
    {
        Hotel = 0,
        Loundry = 1
    }

    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
        public string AuthData { get; set; }
        public int CompanyId { get; set; }
        [Required]
        public PlaceOfWork Workplace { get; set; }
        [Required]
        public Role Permission { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        public Company Company { get; set; }
    }
}