using ZADANIE;

namespace ZADANIE_TEST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(Hello.Test(), true); ;
        }
    }
}