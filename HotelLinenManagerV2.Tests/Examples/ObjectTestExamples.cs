using HotelLinenManagerV2.Tests.PasswordHasherTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.Tests.Examples
{
    [TestClass]
    public class ObjectTestExamples : TestBase
    {
        [TestMethod]
        [Description("Checking: is object user not null")]
        public void IsNullTest()
        {
            //Arrange
            var user = new User();
            //Act
            //Assert
            Assert.IsNotNull(user);
           
        }
        [TestMethod]
        [Description("Checking: is user a User instance")]
        public void IsInstanceOfTypeTest()
        {
            //Arrange
            var user = new User();
            //Assert
            Assert.IsInstanceOfType(user, typeof(User));    
        }
        [TestMethod]
        [Description("Checking: are object the same?")]
        public void AreTheSame()
        {
            //Arrange
            var x = new User();
            var y = new User(); 
            //Assert
            Assert.AreNotSame(x, y);


        }

    }
}
