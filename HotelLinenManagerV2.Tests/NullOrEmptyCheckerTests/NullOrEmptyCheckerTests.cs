

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
    public class NullOrEmptyCheckerTests
    {
        [TestMethod]
        public void MinOneParamIsTrue()
        {
            Assert.Inconclusive();

            //Arrange

            //Act

            //Assert

        }
        [TestMethod]
        public void EveryParamIsFalse()
        {
            Assert.Inconclusive();
        }

        //Obsłużenie testu za pomocą argumentu
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DontHaveIdeaYet()
        {
            Assert.Inconclusive();
        }
        //Obsłużenie testu za pomocą try catch
        [TestMethod]
        public void DontHaveIdeaYet_UsingTryCatch()
        {
            Assert.Inconclusive();
        }
    }
}
