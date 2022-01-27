using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HotelLinenManagerV2.Tests.Examples
{
    ///Przykłady do nauki testów
    [TestClass]
    public class CollectionAssertClassTest
    {
        [TestMethod]
        public void AreCollectionsEquivalentTest()
        {
            var peopleExpected = new List<User>();
            var peopleActual = new List<User>();

            peopleActual.Add(new User() { FistName = "Wojtek",LastName = "Kowalczyk" });
            peopleActual.Add(new User() { FistName = "Piotr",LastName = "Nowak" });
            peopleActual.Add(new User() { FistName = "Andrzej",LastName = "Juskowiak" });

            peopleExpected.Add(peopleActual[2]);    
            peopleExpected.Add(peopleActual[1]);    
            peopleExpected.Add(peopleActual[0]);    

            //Czy kolekcje zawieraja te same obiekty
            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);

        }
        [TestMethod]
        public void IsCollectionOfTypeTest()
        {
            var peopleExpected = new List<User>();
            var peopleActual = new List<User>();

            peopleActual.Add(new User() { FistName = "Wojtek", LastName = "Kowalczyk" });
            peopleActual.Add(new User() { FistName = "Piotr", LastName = "Nowak" });
            peopleActual.Add(new User() { FistName = "Andrzej", LastName = "Juskowiak" });

            peopleExpected.Add(peopleActual[2]);
            peopleExpected.Add(peopleActual[1]);
            peopleExpected.Add(peopleActual[0]);

            //Czy kolekcje zawieraja te same obiekty
            CollectionAssert.AllItemsAreInstancesOfType(peopleActual,typeof(User));

        }
    }
    public class User
    {
        public string FistName { get; set;}
        public string LastName { get; set;}

    }
}
