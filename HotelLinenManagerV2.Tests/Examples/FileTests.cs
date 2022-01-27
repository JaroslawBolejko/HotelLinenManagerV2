using HotelLinenManagerV2.Tests.PasswordHasherTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace HotelLinenManagerV2.Tests.Examples
{
    [TestClass]
    public class FileTests : TestBase
    {

        private string BadFilePath = @"C:\niema.txt";

        [TestMethod]
        public void FileNameDeosExist()
        {

            //Arrange
            FileManager fileManager = new FileManager();
            bool fromCall;
            SetGoodFileName();

            if (!string.IsNullOrEmpty(_GoodFilePath))
            {
                File.AppendAllText(_GoodFilePath, "Test test test");
            }

            //Act
            TestContext.WriteLine("Checking File: " + _GoodFilePath);
            fromCall = fileManager.IsFileExists(_GoodFilePath);

            //Assert
            Assert.IsTrue(fromCall);

            // Delete file
            DeleteFile();
        }
        [TestMethod]
        public void FileNameDeosNotExist()
        {

            //Arrange
            FileManager fileManager = new FileManager();
            bool fromCall;

            //Act
            //TextContext Pozwala wprowadzić dodatkowe info pomocne w analizie testów
            TestContext.WriteLine("Checking File: " + BadFilePath);
            fromCall = fileManager.IsFileExists(BadFilePath);

            //Assert
            Assert.IsFalse(fromCall);
        }


    }
}
