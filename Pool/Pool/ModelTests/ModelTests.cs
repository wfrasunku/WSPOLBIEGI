using System.Collections.ObjectModel;
using Logic;
using Model;

namespace Tests
{
    public class ModelBallTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ModelBallTest()
        {
            Data.BallData ball = new Data.BallData(100, 200, 30, 20, "blue");
            Logic.BallLogic ballLogic = new Logic.BallLogic(ball);
            Model.BallModel ballModel = new Model.BallModel(ballLogic);

            Assert.AreEqual(ball.X, ballLogic.X);
            Assert.AreEqual(ball.Y, ballLogic.Y);
            Assert.AreEqual(ball.Diameter, ballLogic.Diameter);

            Assert.AreEqual(ballModel.X, ballLogic.X);
            Assert.AreEqual(ballModel.Y, ballLogic.Y);
            Assert.AreEqual(ballModel.Diameter, ballLogic.Diameter);
        }
    }
    public class ModelApiTests
    {
        [Test]
        public void ModelApiTest()
        {
            AbstractModelApi modelApi = AbstractModelApi.API();
            modelApi.Start(30);
            
            ObservableCollection<BallModel> balls = modelApi.GetBalls();
            Assert.AreEqual(30, modelApi.GetBalls().Count);
            // Sprawdź, czy dodane kule nie są takie same
            for (int i = 0; i < balls.Count; i++)
            {
                for (int j = i + 1; j < balls.Count; j++)
                {
                    Assert.AreNotEqual(balls[i], balls[j]);
                }
            }
            Assert.NotNull(balls);
        }
    }
}
