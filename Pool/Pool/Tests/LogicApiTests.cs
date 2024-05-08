using Logic;

namespace Tests
{
    public class LogicApiTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void _LogicApiTest()
        {
            AbstractLogicApi api = AbstractLogicApi.API();
            api.StartUpdating(30);
            Assert.AreEqual(30, api.GetBalls().Count);
        }
    }
}

