namespace BlazorApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string AuthData { get; set; }
        public int CompanyId { get; set; }
        public string Permission { get; set; }
        public string Email { get; set; }
        public string PhotoPath { get; set; }

        public Company Company { get; set; }
    }
}