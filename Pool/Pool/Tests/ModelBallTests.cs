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
        public void _ModelBallTest()
        {
            Data.BallData ball = new Data.BallData(100, 200, 30);
            Logic.BallLogic ballLogic = new Logic.BallLogic(ball);

            Assert.AreEqual(ball.X, ballLogic.X);
            Assert.AreEqual(ball.Y, ballLogic.Y);
            Assert.AreEqual(ball.Diameter, ballLogic.Diameter);
        }
    }
}

