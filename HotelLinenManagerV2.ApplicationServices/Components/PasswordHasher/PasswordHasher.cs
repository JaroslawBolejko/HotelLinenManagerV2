using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HotelLinenManagerV2.ApplicationServices.Components.PasswordHasher
{
    public class PasswordHasher : IPasswordHasher
    {
        public string[] Hash(string password)

        {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string saltString = "";
            salt.ToList().ForEach(x => saltString += x.ToString() + "|");

            var base64Code = Encoding.UTF8.GetBytes(saltString);
            string hashedSalt = Convert.ToBase64String(base64Code);


            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            string[] response = { hashed, hashedSalt };
            return response;

        }

        public string HashToCheck(string password, string hashedSalt)
        {
            var base64Encode = Convert.FromBase64String(hashedSalt);
            var encodedSalt = Encoding.UTF8.GetString(base64Encode);

            var saltString = encodedSalt.Split("|");
            if (saltString.Length != 17)
            {
                throw new("hashed Salt bad format");
            }
            byte[] salt = new byte[16];
            for (int i = 0; i < 16; i++)
            {
                salt[i] = Byte.Parse(saltString.ElementAt(i));
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
