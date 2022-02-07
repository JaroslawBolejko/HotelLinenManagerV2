

using HotelLinenManagerV2.ApplicationServices.Components.NullOrEmptyCheker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HotelLinenManagerV2.Tests.NullOrEmptyCheckerTests
{

    //parametr 1 jest null lub empty =>(zwraca) true
    //parametr 2 jest null lub empty => true
    //parametr 3 jest null lub empty => true
    //Jezeli któryś z nich nie jest nullem, ma jakąś zawarotść wtedy metoda zwraca false
    //Czy istnieje jakiś parametr, kótry może spowoidować błąd? np nie da się go zrobić to String?
    //Tak bład jest taki że że parameter nie może być nulllem bo wtedy nie może wywnioskować typu

    // Generalnie metoda do przeróbki, ponieważ po co ma ona generyczne parametry jezeli jako argumenty w handlerze
    //podaje stringi? dlaczego wśród nich nie podaje NIP-u? -bo wtedy zawsze by odpytał APIGUS a nie chce tego, który de facto też jest stringiem.

    // Sprawdzam czy miasto, ulica i nazwa firmy jest nulem lub jest pusta - zawsze przyjdzie puste(chyba ze wypełnione bo tak 
    //zrobiłem clienta ale nie powinno być. A sprawdzam te trzy po prostu dlaetego, że wiem ze jak są puste to mam odpytac gusowskie API
    // jak sa wypełnione to znaczy ze formularz został wypełniony danymi


    [TestClass]
    public class NullOrEmptyCheckerTests : NullCheckerBase
    {
        [ClassInitialize()]
        public static void ClassInitialize(TestContext tc)
        {
            tc.WriteLine("In NullOrCheckerInitialize() method");
        }
        [TestMethod]
        [Owner("Jarek")]
        [Description("Checking if method is returnig true with one,two parameters initialized, empty or null parameters")]
        [Priority(1)]
        public void MinOneParamIsTrue()
        {

            //Arrange
            NullOrEmptyChecker nullOrEmptyChecker = new NullOrEmptyChecker();
            bool fromCall;
            bool fromCallWithAllNull;
            bool fromCallWithAllEmpty;
            bool fromCallStreet;
            //Act
            city = "Jelenia Góra";
            TestContext.WriteLine("checking: is true with one parameter initialized");
            fromCall = nullOrEmptyChecker.IsEmptyOrNull(name, city, street);
            TestContext.WriteLine("checking: is true with two parameter initialized");
            fromCallStreet = nullOrEmptyChecker.IsEmptyOrNull(name, city, street = "Parkowa");
            TestContext.WriteLine("checking: is true with all parameter equal null");
            fromCallWithAllNull = nullOrEmptyChecker.IsEmptyOrNull(name, city = null, street);
            TestContext.WriteLine("checking: is true with empty parameters");
            fromCallWithAllEmpty = nullOrEmptyChecker.IsEmptyOrNull(name = "", city = "", street = "");
            //Assert
            Assert.IsTrue(fromCall);
            Assert.IsTrue(fromCallStreet);
            Assert.IsTrue(fromCallWithAllNull);
            Assert.IsTrue(fromCallWithAllEmpty);
        }
        [TestMethod]
        [Owner("Jarek")]
        [Description("Checking if method is returnig false with all parameters initialized")]
        [Priority(1)]
        public void EveryParamIsFalse()
        {
            //Arange
            NullOrEmptyChecker nullOrEmptyChecker = new NullOrEmptyChecker();
            bool fromCall;
            city = "Cieplice";
            name = "Edward";
            street = "Parkowa";
            //Act
            fromCall = nullOrEmptyChecker.IsEmptyOrNull(name, city, street);
            //Assert
            Assert.IsFalse(fromCall);
        }

       
    }
}
