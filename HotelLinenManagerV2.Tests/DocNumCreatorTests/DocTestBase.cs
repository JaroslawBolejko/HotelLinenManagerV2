using HotelLinenManagerV2.ApplicationServices.Components.DocNumCreator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.Tests.DocNumCreatorTests
{
    public class DocTestBase
    {
        public TestContext TestContext { get; set; }

        public string ValidString { get; set; }
        public string NotValidString { get; set; }
        public string invalidInput = "invalidInput";
        public string randomDocNumber = "1/11/2021";
        public string randomDocNumber2 = "1/01/2022";
        public string nextMonthDocNumber = "1/12/2021";
        public string nextYearDocNumber = "1/1/2022";
        protected void SetProperties()
        {
            this.ValidString = TestContext.Properties["ValidString"].ToString();
            this.NotValidString = TestContext.Properties["NotValidString"].ToString();

        }



        // _ZeroDocNumber = TestContext.Properties["ZeroDocNumber"].ToString();
    }
}
