using HotelLinenManagerV2.ApplicationServices.Components.PasswordHasher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace HotelLinenManagerV2.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }
        private const string GoodPassword = "GoodPassword";

        private const string BadPassword = "BadPassword";


        [TestMethod]
        public void HashingNotNull()
        {
            //Arrange
            PasswordHasher passwordHasher = new PasswordHasher();
            string[] hashedPasswordAndSalt;

            //Act
            TestContext.WriteLine("Checking password:" + GoodPassword);
            hashedPasswordAndSalt = passwordHasher.Hash(GoodPassword);
            //Assert
            Assert.IsNotNull(hashedPasswordAndSalt);
        }
        [TestMethod]
        public void CheckHashBadSaltFormat()
        {
            //Arrange
            PasswordHasher passwordHasher = new PasswordHasher();
            string salt;
            byte[] base64Encode;
            string encodedSalt;
            string[] saltString;
            //Act
            salt = passwordHasher.Hash(GoodPassword)[1];
            base64Encode = Convert.FromBase64String(salt);
            encodedSalt = Encoding.UTF8.GetString(base64Encode);
            saltString = encodedSalt.Split("|");
            TestContext.WriteLine("Checking password: " + GoodPassword);

            //Assert
            Assert.AreEqual(saltString.Length, 17);
        }
        [TestMethod]
        public void HashingAndCheckHashingIsTrue()
        {
            //Arrange
            PasswordHasher passwordHasher = new PasswordHasher();
            string[] hashedPasswordAndSalt;
            string hashedPassword;
            //Act
            TestContext.WriteLine("Checking password: " + GoodPassword);
            hashedPasswordAndSalt = passwordHasher.Hash(GoodPassword);
            hashedPassword = passwordHasher.HashToCheck(GoodPassword, hashedPasswordAndSalt[1]);
            //Assert
            Assert.AreEqual(hashedPassword, hashedPasswordAndSalt[0]);
        }
        [TestMethod]
        public void HashingAndCheckHashingIsFlase()
        {
            //Arrange
            PasswordHasher passwordHasher = new PasswordHasher();
            string[] hashedPasswordAndSalt;
            string hashedPassword;

            //Act
            TestContext.WriteLine("Checking password: " + GoodPassword);
            hashedPasswordAndSalt = passwordHasher.Hash(GoodPassword);
            hashedPassword = passwordHasher.HashToCheck(BadPassword, hashedPasswordAndSalt[1]);

            //Assert

            Assert.AreNotEqual(hashedPassword, hashedPasswordAndSalt[0]);
        }
    }
}
