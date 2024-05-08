using Logic;
using Data;

namespace Tests
{
    public class LogicTests
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
        //[Test]
        //public void AddBallTest()
        //{
        //    AbstractLogicApi api = AbstractLogicApi.API();
        //    api.StartUpdating(30);
        //    Assert.AreEqual(30, api.GetBalls().Count);
        //    //api.AddBall();
        //    //api.RemoveBall();
        //    //Assert.AreEqual(30, api.GetBalls().Count);
        //}
    }
    public class BallLogicTests
    {
        [Test]
        public void GetterTest() 
        {
            BallData ball = new BallData(30, 40, 20);
            BallLogic logicBall = new BallLogic(ball);
            Assert.AreEqual(30, logicBall.X);
            Assert.AreEqual(40, logicBall.Y);
            Assert.AreEqual(20, logicBall.Diameter);
        }
        [Test]
        public void SetterTest()
        {
            BallData ball = new BallData(30, 40, 20);
            BallLogic logicBall = new BallLogic(ball);
            logicBall.X = 60;
            logicBall.Y = 80;
            Assert.AreEqual(60, logicBall.X);
            Assert.AreEqual(80, logicBall.Y);
        }
    }
}

