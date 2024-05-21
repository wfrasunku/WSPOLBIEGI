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
        public void AddRemoveBallTest()
        {
            api.StartUpdating(5);
            api.AddBall();
            Assert.AreEqual(6, api.GetBalls().Count);

            api.RemoveBall();
            Assert.AreEqual(5, api.GetBalls().Count);
        }

        /*[Test]
        public void CollisionTest()
        {
            api.StartUpdating(2);

            List<BallLogic> balls = api.GetBalls();
            BallLogic ball1 = balls[0];
            BallLogic ball2 = balls[1];

            // Ustawiamy pozycje kul tak, aby doszło do kolizji
            ball1.X = 100;
            ball1.Y = 100;
            ball1.SetSpeed(1, 0);

            ball2.X = 120;
            ball2.Y = 100;
            ball2.SetSpeed(-1, 0);

            // Symulacja kolizji
            api.CheckCollision(ball1.ball, new PropertyChangedEventArgs(nameof(ball1.ball.X)));
            api.CheckCollision(ball2.ball, new PropertyChangedEventArgs(nameof(ball2.ball.X)));

            // Sprawdzamy, czy po kolizji zmieniły się prędkości kul
            Assert.AreEqual(-1, ball1.ball.XSpeed);
            Assert.AreEqual(1, ball2.ball.XSpeed);
        }*/

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

        /*[Test]
        public void CollisionFieldTest()
        {
            logicBall.X = 5;
            logicBall.Y = 5;
            logicBall.SetSpeed(-2, -3);
            api.CheckCollision(logicBall.ball, new PropertyChangedEventArgs(nameof(logicBall.ball.X)));
            api.CheckCollision(logicBall.ball, new PropertyChangedEventArgs(nameof(logicBall.ball.Y)));

            Assert.AreEqual(2, logicBall.ball.XSpeed);
            Assert.AreEqual(3, logicBall.ball.YSpeed);

            logicBall.X = 775;
            logicBall.Y = 375;
            logicBall.SetSpeed(2, 3);
            api.CheckCollision(logicBall.ball, new PropertyChangedEventArgs(nameof(logicBall.ball.X)));
            api.CheckCollision(logicBall.ball, new PropertyChangedEventArgs(nameof(logicBall.ball.Y)));

            Assert.AreEqual(-2, logicBall.ball.XSpeed);
            Assert.AreEqual(-3, logicBall.ball.YSpeed);
        }*/
    }
}

