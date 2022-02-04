using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HotelLinenManagerV2.Tests.PasswordHasherTests
{
    public class TestBase
    {
        public TestContext TestContext { get; set; }
        protected string _GoodFilePath;
        public DataTable TestDataTable { get; set; }
        public  DataTable LocalDataTable(string sql, string connetion)
        {
            TestDataTable = null;
            try
            {
                using SqlConnection ConnectionObject = new SqlConnection(connetion);
                using SqlCommand CommandObject = new SqlCommand(sql, ConnectionObject);
                using SqlDataAdapter dataAdapter = new SqlDataAdapter(CommandObject);
                TestDataTable = new DataTable();
                dataAdapter.Fill(TestDataTable);
            }
            catch(Exception ex)
            {
                TestContext.WriteLine("Error in LoadDataTable() method." + Environment.NewLine 
                    + ex.ToString());            
            }
            return TestDataTable;
        }

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
        //protected void WriteDescription(Type type)
        //{
        //    var testName = TestContext.TestName;
        //    var method = type.GetMethod(testName);

        //    if (method != null)
        //    {
        //        var attribute = method.GetCustomAttributes(typeof(DescriptionAttribute));
        //        if (attribute != null)
        //        {
        //            var datr =  (DescriptionAttribute)attribute.FirstOrDefault();
        //            TestContext.WriteLine("Test Description: " + datr.Description);
        //        }

        //    }
        //}

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
