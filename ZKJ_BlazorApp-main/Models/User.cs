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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string AuthData { get; set; }
        public int CompanyId { get; set; }
        public PlaceOfWork Workplace { get; set; }
        public Role Permission { get; set; }
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public Company Company { get; set; }
    }
}