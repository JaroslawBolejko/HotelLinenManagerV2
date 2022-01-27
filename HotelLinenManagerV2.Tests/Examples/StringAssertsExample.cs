using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace HotelLinenManagerV2.Tests.Examples
{

    //Przykłady do nauki testów
    [TestClass]
    public class StringAssertsExample
    {
        [TestMethod]
        public void ContainsTest()
        {
            string str1 = "Adam";
            string str2 = "Adam Małysz";

            StringAssert.Contains(str1, str2);

        }
        [TestMethod]
        public void StartsWithTest()
        {
            string str1 = "Adam Małysz";
            string str2 = "Adam";

            StringAssert.StartsWith(str1, str2);

        }
        [TestMethod]
        public void AreEqualTest()
        {
            string str1 = "Adam";
            string str2 = "adam";

            Assert.AreEqual(str1, str2,true);// true-ignore case

        }
        [TestMethod]
        public void AreNotEqualTest()
        {
            string str1 = "Adam Małysz";
            string str2 = "Adam";

            Assert.AreNotEqual(str1, str2);

        }
        [TestMethod]
        public void IsAllowLowerCase()
        {
            var r = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("Wszystko małymi", r);

        }
        [TestMethod]
        public void IsNotAllowLowerCase()
        {
            var r = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("Wszystko małymi", r);

        }

    }
}
