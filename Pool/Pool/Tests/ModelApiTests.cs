using System.Collections.ObjectModel;
using Logic;
using Model;

namespace Tests
{
    public class ModelApiTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void _ModelApiTest()
        {
            AbstractLogicApi logicApi = AbstractLogicApi.API();
            AbstractModelApi modelApi = AbstractModelApi.API();
            modelApi.Start(30);
            ObservableCollection<BallModel> balls = modelApi.GetBalls();
            Assert.AreEqual(30, modelApi.GetBalls().Count);
            Assert.NotNull(balls);
        }
    }
}

