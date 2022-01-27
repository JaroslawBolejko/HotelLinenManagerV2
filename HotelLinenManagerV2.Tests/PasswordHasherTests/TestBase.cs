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
                File.Delete(_GoodFilePath);
            }
        }

    }
}
