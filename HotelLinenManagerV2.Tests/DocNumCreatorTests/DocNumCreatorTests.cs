using HotelLinenManagerV2.ApplicationServices.Components.DocNumCreator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace HotelLinenManagerV2.Tests.DocNumCreatorTests
{
    [TestClass]
    public class DocNumCreatorTests : DocTestBase
    {
        /*jako parametr przychodzi do metody string, który jest numerem faktury: 
         -  jezeli ten string to "0/0/0(nie było wcześniej faktur w bazie) wtedy zwraca 1/biezący miesiąc/bieżacy rok
          Czy to co przychodzi jest w dopowiednim formacie? tzn czy ma postać "int'/'int'/'int"
        -czyli posiada dwa '/' i trzy inty.
        - jezeli numer jest inny ni z 0/0/0 to następuje :
                var tabOfNumbersFromDocument = str.Split("/", StringSplitOptions.RemoveEmptyEntries);
                var docNumber = int.Parse(tabOfNumbersFromDocument[0]);
                var month = int.Parse(tabOfNumbersFromDocument[1]);
                var year = int.Parse(tabOfNumbersFromDocument[2]);
        wyciągniecie odpowiednich wartości numerycznych ze stringa i sprawdzenie
        - czy numer bieżącego miesiąca(month) jest wiekszy od wyciagniętego ze stringa, jeżeli tak zwiększ o jeden, a doc numer otrzymuje
        watrtośc 1, mięsiąc otrzymuje wartość bieżacego miesiąca, rok bieżocego roku
        -Czy numer bięzocego roku jest większy od wyciągnietego(year) jezeli tak to docNumer ma 1, month ma bieżący miesiąc a rok bieżący rok
       w pozostałych przypadkach ma zwiększyc numer dokumentu o 1;
        */


        [TestMethod]
        public void IsStrValid()
        {
            //Arrange
            string[] tabOfNumbersFromDocument;
            string docNumber;
            string month;
            string year;
            //Act
            SetProperties();
            tabOfNumbersFromDocument = ValidString.Split('/');
            TestContext.WriteLine("checking: document number type ");
            docNumber = tabOfNumbersFromDocument[0];
            TestContext.WriteLine("checking: document month type ");
            month = tabOfNumbersFromDocument[1];
            TestContext.WriteLine("checking: document year type ");
            year = tabOfNumbersFromDocument[2];

            //Assert
            Assert.AreEqual(int.Parse(docNumber).GetType(), typeof(int));
            Assert.AreEqual(int.Parse(month).GetType(), typeof(int));
            Assert.AreEqual(int.Parse(year).GetType(), typeof(int));
        }

        [TestMethod]
        [Owner("Jarek")]
        [Description("Check if passed string trows a FormatException")]
        [ExpectedException(typeof(FormatException))]
        public void IsStrNotValid_UsingAtribute()
        {
            //Arrange
            string[] tabOfNumbersFromDocument;
            int docNumber;
            int month;
            int year;
            //Act
            SetProperties();
            tabOfNumbersFromDocument = NotValidString.Split('/');
            TestContext.WriteLine("checking: document number type ");
            docNumber = int.Parse(tabOfNumbersFromDocument[0]);
            TestContext.WriteLine("checking: document month type ");
            month = int.Parse(tabOfNumbersFromDocument[1]);
            TestContext.WriteLine("checking: document year type ");
            year = int.Parse(tabOfNumbersFromDocument[2]);

        }

        [TestMethod]
        [Owner("Jarek")]
        [Description("Check if passed string is in valid format")]
        [Priority(1)]
        public void IsStrValid_UsingRegex()
        {
            //Arrange
            var r = new Regex(@"^[0-9]+[/][0-9]+[/][0-9]+$");

            //Act
            SetProperties();

            //Assert
            StringAssert.Matches(ValidString, r);

        }
        [TestMethod]
        [Owner("Jarek")]
        [Description("Check if passed in string is in valid format")]
        [Priority(1)]
        public void IsStrNotValid_UsingRegex()
        {
            //Arrange
            var r = new Regex(@"^[0-9]+[/][0-9]+[/][0-9]+$");

            //Act

            //Assert
            StringAssert.DoesNotMatch(invalidInput, r);

        }

        [TestMethod]
        [Owner("Jarek")]
        [Description("Check if documents number middle argument (month) equals current month")]
        [Priority(1)]
        public void IsNextMounth()
        {

            //Arrange
            DocNumCreator docNumberCreator = new();
            string[] tabOfNumbersFromDocument;
            int month;
            //Act
            nextMonthDocNumber = docNumberCreator.DocumentNumberCreator(nextMonthDocNumber);
            tabOfNumbersFromDocument = nextMonthDocNumber.Split('/');
            TestContext.WriteLine("checking: is document month equals current month");
            month = int.Parse(tabOfNumbersFromDocument[1]);
            //Assert
            Assert.AreEqual(month, DateTime.Now.Month);

        }
        [TestMethod]
        [Owner("Jarek")]
        [Description("Check if documents number third argument(year) equals current year")]
        [Priority(1)]
        public void IsNextYear()
        {
            //Arrange
            DocNumCreator docNumberCreator = new();
            string[] tabOfNumbersFromDocument;
            int year;
            string YearDocNumber;
            //Act
            YearDocNumber = docNumberCreator.DocumentNumberCreator(nextYearDocNumber);
            tabOfNumbersFromDocument = YearDocNumber.Split('/');
            TestContext.WriteLine("checking: is document year equals current year");
            year = int.Parse(tabOfNumbersFromDocument[2]);
            //Assert
            Assert.AreEqual(year, DateTime.Now.Year);
        }
        [TestMethod]
        [Priority(1)]
        [Owner("Jarek")]
        [Description("Check if documents number first argument(consecutive number) equals is incrementing")]
        public void IsNextDocNumber()
        {
            //Arrange
            DocNumCreator docNumberCreator = new();
            string[] tabOfNumbersFromNextDocument;
            string[] tabOfNumbersFromPreviousDocument;
            string nextDocNumber;
            int docNumber;
            int nextNumber;
            //Act
            nextDocNumber = docNumberCreator.DocumentNumberCreator(randomDocNumber2);
            tabOfNumbersFromNextDocument = nextDocNumber.Split('/');
            tabOfNumbersFromPreviousDocument = randomDocNumber2.Split('/');
            TestContext.WriteLine("checking: is document number increasing by 1");
            docNumber = int.Parse(tabOfNumbersFromPreviousDocument[0]);
            nextNumber = int.Parse(tabOfNumbersFromNextDocument[0]);
            //Assert
            Assert.AreEqual(docNumber + 1, nextNumber);
        }
        [TestMethod]
        [Priority(1)]
        [Owner("Jarek")]
        [Description("Check if first document number is created")]
        public void IsFirstDocNumber()
        {
            //Arrange
            DocNumCreator docNumberCreator = new();
            string[] tabOfNumbersDocument;
            string firstDocNumber;
            int docNumber;
            //Act
            SetProperties();
            firstDocNumber = docNumberCreator.DocumentNumberCreator(ValidString);
            tabOfNumbersDocument = firstDocNumber.Split('/');
            TestContext.WriteLine("checking: is document number equals 1");
            docNumber = int.Parse(tabOfNumbersDocument[0]);
            //Assert
            Assert.AreEqual(docNumber, 1);
        }
    }
}
