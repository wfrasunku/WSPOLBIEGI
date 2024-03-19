using ZADANIE;

namespace ZADANIE_TEST
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            Assert.AreEqual(Trust.DoYouTrustMe(), true); ;
        }
    }
}