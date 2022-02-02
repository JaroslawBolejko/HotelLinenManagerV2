using HotelLinenManagerV2.Tests.PasswordHasherTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace HotelLinenManagerV2.Tests.Examples
{
    [TestClass]
    public class FileTests : TestBase
    {

        private string BadFilePath = @"C:\niema.txt";


        [TestInitialize]
        public void TestInitialize()
        {
            //Metoda która jest uruchomiana za kazdym razem kiedy test są odpalone , dobra dla inicjlizacji danych
            TestContext.WriteLine("In TestInitialize() method");

            SetGoodFileName();

            if (!string.IsNullOrEmpty(_GoodFilePath))
            {
                TestContext.WriteLine("Creating file: " + _GoodFilePath);

                File.AppendAllText(_GoodFilePath, "Test test test");
            }
        }
        [TestCleanup]
        public  void TestCleanup()
        {
            TestContext.WriteLine("In Testclenup() method");
            DeleteFile();

        }

        [TestMethod]
        public void FileNameDeosExist()
        {

            //Arrange
            FileManager fileManager = new FileManager();
            bool fromCall;
           

            //Act
            TestContext.WriteLine("Checking File: " + _GoodFilePath);
            fromCall = fileManager.IsFileExists(_GoodFilePath);

            //Assert
            Assert.IsTrue(fromCall);

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
        [TestMethod]
        public void IsSwapWorksTest()
        {
            //Arrange
            int  a = 8;
            int  b = 10;
            int result;
            int result2;
            int[] resArr;
            int[] init = new int[] {a,b};

            //Act

            TestContext.WriteLine("Checking variable: " + a);
            result = Swapa(a,b);
            TestContext.WriteLine("Checking variable: " + b);
            result2 = Swapb(a,b);
            TestContext.WriteLine($"Checking array that consist of: " +a+" "+b);
            resArr = SwapArr(a, b); 
            

            //Assert
            Assert.AreNotEqual(init, resArr);
            Assert.AreEqual(b, result);
            Assert.AreEqual(a, result2);


        }
        [TestMethod]
        [Owner("Jarek")]
        [Description("simple test, just to practise DataRowAtribute")]
        [DataRow(1,21,DisplayName ="NumbersAreEqual")]
        [DataRow(55,55,DisplayName ="NumbersAreEqual")]
        [DataRow(18,18,DisplayName ="NumbersAreEqual")]
        public void AreNumberEqual(int a, int b)
        {
            Assert.AreEqual((int)a, (int)b);
        }

        [TestMethod]
        [DeploymentItem("file.txt")]
        [DataRow(@"C:\windows\notepad.exe", DisplayName = "FileNameUsingDataRow")]
        [DataRow("file.txt", DisplayName = "FileNameUsingDataRow")]
        public void FileNameDeosExist_UsingDataRow_Deploy(string fileName)
        {

            //Arrange
            FileManager fileManager = new FileManager();
            bool fromCall;


            //Act
            if (!fileName.Contains(@"\"))
            {
                fileName = TestContext.DeploymentDirectory + @"\Examples\" + fileName;
            }

            TestContext.WriteLine("Checking file: " + fileName);
            fromCall = fileManager.IsFileExists(fileName);

            //Assert
            Assert.IsTrue(fromCall);

        }

    }
}
