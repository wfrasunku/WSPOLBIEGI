using Logic;
using Data;
using System.ComponentModel;

namespace Tests
{
    public class LogicApiTests
    {
        private AbstractLogicApi api;

        [SetUp]
        public void Setup()
        {
            api = AbstractLogicApi.API();
        }

        [Test]
        public void LogicApiTest()
        {
            api.StartUpdating(30);
            Assert.AreEqual(30, api.GetBalls().Count);
        }

        [Test]
        public void FieldCollisionTest()
        {
            api.StartUpdating(1);
            //var ball = api.GetBalls().First();

            // Test kolizji z lewą ścianą
            api.GetBalls().First().X = 0;
            api.GetBalls().First().SetSpeed(-2, 0);

            System.Threading.Thread.Sleep(20);
            Assert.AreNotEqual(-2, api.GetBalls().First().XSpeed);


            // Test kolizji z prawą ścianą
            api.GetBalls().First().X = 780 - api.GetBalls().First().Diameter;
            api.GetBalls().First().SetSpeed(2, 0);

            System.Threading.Thread.Sleep(50);
            Assert.AreNotEqual(2, api.GetBalls().First().XSpeed);

            // Test kolizji z górną ścianą
            api.GetBalls().First().Y = 0;
            api.GetBalls().First().SetSpeed(0, -2);

            System.Threading.Thread.Sleep(50);
            Assert.AreNotEqual(-2, api.GetBalls().First().YSpeed);


            // Test kolizji z dolną ścianą
            api.GetBalls().First().Y = 380 - api.GetBalls().First().Diameter;
            api.GetBalls().First().SetSpeed(0, 2);

            System.Threading.Thread.Sleep(50);
            Assert.AreNotEqual(2, api.GetBalls().First().YSpeed);
        }

        [Test]
        public void BallCollisionTest()
        {
            api.StartUpdating(2);

            Console.WriteLine("Pozycja kulki 1: (" + api.GetBalls().First().X + ", " + api.GetBalls().First().Y + ")");
            Console.WriteLine("Prędkość kulki 1: (" + api.GetBalls().First().XSpeed + ", " + api.GetBalls().First().YSpeed + ")");
            Console.WriteLine("Pozycja kulki 2: (" + api.GetBalls().Last().X + ", " + api.GetBalls().Last().Y + ")");
            Console.WriteLine("Prędkość kulki 2: (" + api.GetBalls().Last().XSpeed + ", " + api.GetBalls().Last().YSpeed + ")");

            Console.WriteLine("po ustawieniu wartosci");

            api.GetBalls().First().SetSpeed(2, 0);
            api.GetBalls().Last().SetSpeed(-2, 0);
            api.GetBalls().First().X = 100;
            api.GetBalls().Last().X = 120;
            api.GetBalls().First().Y = api.GetBalls().Last().Y = 100;

            Console.WriteLine("Pozycja kulki 1: (" + api.GetBalls().First().X + ", " + api.GetBalls().First().Y + ")");
            Console.WriteLine("Prędkość kulki 1: (" + api.GetBalls().First().XSpeed + ", " + api.GetBalls().First().YSpeed + ")");
            Console.WriteLine("Pozycja kulki 2: (" + api.GetBalls().Last().X + ", " + api.GetBalls().Last().Y + ")");
            Console.WriteLine("Prędkość kulki 2: (" + api.GetBalls().Last().XSpeed + ", " + api.GetBalls().Last().YSpeed + ")");

            System.Threading.Thread.Sleep(50);
            Console.WriteLine("po Sleep");

            Console.WriteLine("Pozycja kulki 1: (" + api.GetBalls().First().X + ", " + api.GetBalls().First().Y + ")");
            Console.WriteLine("Prędkość kulki 1: (" + api.GetBalls().First().XSpeed + ", " + api.GetBalls().First().YSpeed + ")");
            Console.WriteLine("Pozycja kulki 2: (" + api.GetBalls().Last().X + ", " + api.GetBalls().Last().Y + ")");
            Console.WriteLine("Prędkość kulki 2: (" + api.GetBalls().Last().XSpeed + ", " + api.GetBalls().Last().YSpeed + ")");

            Assert.AreNotEqual(2, api.GetBalls().First().XSpeed);
            Assert.AreNotEqual(-2, api.GetBalls().Last().XSpeed);

        }
    }

    public class BallLogicTests
    {
        private BallData ball;
        private BallLogic logicBall;
        //private AbstractLogicApi api;

        [SetUp]
        public void Setup()
        {
            ball = new BallData(30, 40, 20, 20, "Blue");
            logicBall = new BallLogic(ball);
            //api = AbstractLogicApi.API();
        }

        [Test]
        public void GetterTest() 
        {
            Assert.AreEqual(30, logicBall.X);
            Assert.AreEqual(40, logicBall.Y);
            Assert.AreEqual(20, logicBall.Diameter);
            Assert.AreEqual(20, logicBall.Mass);
            Assert.AreEqual("Blue", logicBall.Color);
        }

        [Test]
        public void SetterTest()
        {
            logicBall.X = 60;
            logicBall.Y = 80;
            Assert.AreEqual(60, logicBall.X);
            Assert.AreEqual(80, logicBall.Y);
        }

        [Test]
        public void PropertyChangedTest()
        {
            bool xChanged = false;
            bool yChanged = false;
            bool diameterChanged = false;

            logicBall.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(BallLogic.X))
                    xChanged = true;
                else if (e.PropertyName == nameof(BallLogic.Y))
                    yChanged = true;
                else if (e.PropertyName == nameof(BallLogic.Diameter))
                    diameterChanged = true;
            };

            // Zmiana X
            logicBall.X = 50;
            Assert.IsTrue(xChanged);

            // Zmiana Y
            logicBall.Y = 60;
            Assert.IsTrue(yChanged);
        }
    }
}

