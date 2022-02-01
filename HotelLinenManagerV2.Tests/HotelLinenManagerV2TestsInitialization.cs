using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelLinenManagerV2.Tests
{
    [TestClass]
    public class HotelLinenManagerV2TestsInitialization
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext tc)
        {
            //Initialize pojawia się raz w pierwszym tescie z całej grupy , kótra została uruchamiana
            tc.WriteLine("In AssemblyInitialize() method");
        }
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            //Clean Up
        }
    }
}
