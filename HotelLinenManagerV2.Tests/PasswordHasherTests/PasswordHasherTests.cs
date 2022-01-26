using HotelLinenManagerV2.ApplicationServices.Components.PasswordHasher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace HotelLinenManagerV2.Tests.PasswordHasherTests
{
    [TestClass]
    public class PasswordHasherTests : TestBase

    {
        private const string GoodPassword = "GoodPassword";

        private const string BadPassword = "BadPassword";


        [TestMethod]
        [Owner("Jarek")]
        [Priority(1)]
        [TestCategory("WithoutException")]
        [Description("Check if hashedPassword is not null")]
        public void HashingNotNull()
        {
            //Arrange
            PasswordHasher passwordHasher = new();
            string[] hashedPasswordAndSalt;

            //Act
            var goodPasswordName = TestContext.Properties["GoodPassword"].ToString();
            TestContext.WriteLine("Checking password: " + goodPasswordName);
            hashedPasswordAndSalt = passwordHasher.Hash(goodPasswordName);
            //Assert
            Assert.IsNotNull(hashedPasswordAndSalt);
        }

        [TestMethod]
        [Owner("Jarek")]
        [Description("Check if hashedPassword is not null")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HashingNotNull_UsingAtribute()
        {
            //Arrange
            PasswordHasher passwordHasher = new();
            string nullStr = null;
            //Act
            passwordHasher.Hash(nullStr);
        }
        [TestMethod]
        [Owner("Jarek")]
        [Priority(2)]
        [Description("Check if hashedPassword is not null")]
        public void HashingNotNull_UsingTryCatch()
        {
            //Arrange
            PasswordHasher passwordHasher = new();
            string nullStr = null;
            //Act
            try
            {
                passwordHasher.Hash(nullStr);

            }
            catch (ArgumentNullException)
            {
                return;
            }
            Console.WriteLine("Call to Hash() did not throw ArgumentNullException");
        }

        [TestMethod]
        [Owner("Jarek")]
        [Description("Check if salt is in proper format")]


        public void CheckHashBadSaltFormat()
        {
            //Arrange
            PasswordHasher passwordHasher = new();
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
        [Owner("Jarek")]
        [Description("Chcek if password hash and hash to check return the same result with the same password")]


        public void HashingAndCheckHashingIsTrue()
        {
            //Arrange
            PasswordHasher passwordHasher = new();
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
        [Owner("Jarek")]
        [Priority(1)]
        [TestCategory("WithException")]
        [Description("Chcek if methid Hash and HashToCheck return the same result with different passwords")]


        public void HashingAndCheckHashingIsFlase()
        {
            //Arrange
            PasswordHasher passwordHasher = new();
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
