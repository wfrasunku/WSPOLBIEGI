using Data;

namespace Tests
{
    public class BallDataTests
    {
        private BallData ball;

        [SetUp]
        public void Setup()
        {
            ball = new BallData(30, 40, 20, 20, "Blue");
        }

        [Test]
        public void GetterTest()
        {
            Assert.AreEqual(30, ball.X);
            Assert.AreEqual(40, ball.Y);
            Assert.AreEqual(20, ball.Diameter);
            Assert.AreEqual(20, ball.Mass);
            Assert.AreEqual("Blue", ball.Color);
        }

        [Test]
        public void SetterTest()
        {
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
            Assert.AreEqual(20, ball.Mass);
            Assert.AreEqual("Blue", ball.Color);

        }

        [Test]
        public void SetSpeedTest()
        {
            ball.SetSpeed(21, 25);
            Assert.AreEqual(2, ball.XSpeed);
            Assert.AreEqual(2, ball.YSpeed);

            ball.SetSpeed(5, 5);
            Assert.AreEqual(5, ball.XSpeed);
            Assert.AreEqual(5, ball.YSpeed);
        }

        [Test]
        public void ActualPositionTest()
        {
            ball.ActualPosition(100, 200);
            Assert.AreEqual(100, ball.X);
            Assert.AreEqual(200, ball.Y);
        }
    }
   
    public class DataApiTest
    {
        private AbstractDataApi api;

        [SetUp]
        public void Setup()
        {
            api = new AbstractDataApi.DataApi();
        }

        [Test]
        public void CreatePoolTest()
        {
            api.CreatePool(5, 380, 780);

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
            api.CreatePool(5, 380, 780);
            BallData ball = api.GetBalls().First();

            Assert.IsNotNull(ball);
            // Sprawdź czy współrzędne i prędkości są w odpowiednich zakresach
            Assert.GreaterOrEqual(ball.X, 100);
            Assert.LessOrEqual(ball.X, 700);

            Assert.GreaterOrEqual(ball.Y, 100);
            Assert.LessOrEqual(ball.Y, 300);

            Assert.IsTrue(ball.XSpeed >= -5 && ball.XSpeed <= 5);
            Assert.IsTrue(ball.YSpeed >= -5 && ball.YSpeed <= 5);
        }

        [Test]
        public void BallColorTest()
        {
            BallData ball = AbstractDataApi.DataApi.CreateBall(200, 240, "Red");
            Assert.AreEqual("Red", ball.Color);

            ball = AbstractDataApi.DataApi.CreateBall(200, 240, "Red");
            string[] validColors = { "Yellow", "Blue", "Red", "Purple", "Orange", "Green", "Brown", "Black" };
            CollectionAssert.Contains(validColors, ball.Color);
        }
    }

    public class PoolTableTests
    {
        private PoolTable table;

        [SetUp]
        public void Setup()
        {
            table = new PoolTable(380, 780);
        }

        [Test]
        public void GetterTest()
        {
            Assert.AreEqual(380, table.Height);
            Assert.AreEqual(780, table.Width);
        }
    }
}