namespace HotelLinenManagerV2.ApplicationServices.Components.PasswordHasher
{ 
    public interface IPasswordHasher
    {
        public string[] Hash(string password);
        public string HashToCheck(string password, string hashedSalt);

    }
}