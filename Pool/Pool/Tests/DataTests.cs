using Data;

namespace Tests
{
    public class BallDataTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetterTest()
        {
            BallData ball = new BallData(30, 40, 20);
            Assert.AreEqual(30, ball.X);
            Assert.AreEqual(40, ball.Y);
            Assert.AreEqual(20, ball.Diameter);
        }

        [Test]
        public void SetterTest()
        {
            BallData ball = new BallData(30, 40, 20);
            ball.SetSpeed(2, 3);
            ball.X = 50;
            ball.Y = 60;
            ball.Diameter = 30;

            Assert.AreNotEqual(30, ball.X);
            Assert.AreNotEqual(40, ball.Y);
            Assert.AreNotEqual(20, ball.XSpeed);

            Assert.AreEqual(2, ball.XSpeed);
            Assert.AreEqual(3, ball.YSpeed);
            Assert.AreEqual(50, ball.X);
            Assert.AreEqual(60, ball.Y);
            Assert.AreEqual(30, ball.Diameter);
            
        }
    }
    public class DataApiTests
    {
        [Test]
        public void DataApiTest()
        {
            AbstractDataApi api = AbstractDataApi.API();
            api.CreatePool(12);
            Assert.AreEqual(12, api.GetBalls().Count);

        }
    }
}