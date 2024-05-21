using Logic;
using Data;

namespace Tests
{
    public class LogicApiTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LogicApiTest()
        {
            AbstractLogicApi api = AbstractLogicApi.API();
            api.StartUpdating(30);
            Assert.AreEqual(30, api.GetBalls().Count);
        }
    }
    public class BallLogicTests
    {
        [Test]
        public void GetterTest() 
        {
            BallData ball = new BallData(30, 40, 20, 20, "blue");
            BallLogic logicBall = new BallLogic(ball);
            Assert.AreEqual(30, logicBall.X);
            Assert.AreEqual(40, logicBall.Y);
            Assert.AreEqual(20, logicBall.Diameter);
        }
        [Test]
        public void SetterTest()
        {
            BallData ball = new BallData(30, 40, 20, 20, "blue");
            BallLogic logicBall = new BallLogic(ball);
            logicBall.X = 60;
            logicBall.Y = 80;
            Assert.AreEqual(60, logicBall.X);
            Assert.AreEqual(80, logicBall.Y);
        }
        [Test]
        public void PropertyChangedTest()
        {
            BallData ball = new BallData(30, 40, 20, 20, "blue");
            BallLogic logicBall = new BallLogic(ball);

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

