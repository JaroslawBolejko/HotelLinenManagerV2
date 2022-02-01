using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace HotelLinenManagerV2.Tests.PasswordHasherTests
{
    public class TestBase
    {
        public TestContext TestContext { get; set; }
        protected string _GoodFilePath;
       

        protected void SetGoodFileName()
        {
            // dobra metoda do przeniesienia na testinitialize
            _GoodFilePath = TestContext.Properties["GoodFilePath"].ToString();
            if (_GoodFilePath.Contains("[AppPath]"))
            {
                _GoodFilePath = _GoodFilePath.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        protected void DeleteFile()
        {
            if (File.Exists(_GoodFilePath))
            {
                TestContext.WriteLine("Deleting file: " + _GoodFilePath);
                File.Delete(_GoodFilePath);
            }
        }
        public int Swapa(int a, int b)
        {
            int c = a;
            a = b;
            b = c;
            return a;
        }
        public int Swapb(int a, int b)
        {
            int c = a;
            a = b;
            b = c;
            return b;
        }
        public int[] SwapArr(int a, int b)
        {
            int c = a;
            a = b;
            b = c;
            int[] result = new int[2] { a, b };
            return result;
        }
    }
}
