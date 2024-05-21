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
            BallData ball = new BallData(30, 40, 20, 20, "blue");
            Assert.AreEqual(30, ball.X);
            Assert.AreEqual(40, ball.Y);
            Assert.AreEqual(20, ball.Diameter);
        }

        [Test]
        public void SetterTest()
        {
            BallData ball = new BallData(30, 40, 20, 20, "blue");
            ball.SetSpeed(2, 3);
            ball.X = 50;
            ball.Y = 60;

            Assert.AreNotEqual(30, ball.X);
            Assert.AreNotEqual(40, ball.Y);
            Assert.AreNotEqual(20, ball.XSpeed);

            Assert.AreEqual(2, ball.XSpeed);
            Assert.AreEqual(3, ball.YSpeed);
            Assert.AreEqual(50, ball.X);
            Assert.AreEqual(60, ball.Y);
            Assert.AreEqual(20, ball.Diameter);
            
        }
    }
   
    public class DataApiTest
    {
        [Test]
        public void CreatePoolTest()
        {
            Data.AbstractDataApi api = new Data.AbstractDataApi.DataApi();
            api.CreatePool(5);

            List<BallData> balls = api.GetBalls();
            Assert.AreEqual(5, balls.Count);

            // Sprawdź czy prędkości początkowe są ustawione
            foreach (var ball in balls)
            {
                Assert.AreNotEqual(0, ball.XSpeed);
                Assert.AreNotEqual(0, ball.YSpeed);
            }
        }

        [Test]
        public void CreateBallTest()
        {
            Data.AbstractDataApi api = new Data.AbstractDataApi.DataApi();
            api.CreatePool(5);
            BallData ball = api.GetBalls().First();

            Assert.IsNotNull(ball);
            // Sprawdź czy współrzędne i prędkości są w odpowiednich zakresach
            Assert.GreaterOrEqual(ball.X, 100);
            Assert.LessOrEqual(ball.X, 700);

            Assert.GreaterOrEqual(ball.Y, 100);
            Assert.LessOrEqual(ball.Y, 300);

            Assert.IsTrue(ball.XSpeed >= -2 && ball.XSpeed <= 2);
            Assert.IsTrue(ball.YSpeed >= -2 && ball.YSpeed <= 2);
        }
    }
}