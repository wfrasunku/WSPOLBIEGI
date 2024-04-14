using ZADANIE;

namespace ZADANIE_TEST
{
    [TestClass]
    public class BallTests
    {
        [TestMethod]
        public void Ball_Move_ShouldUpdatePosition()
        {
            Ball ball = new Ball(0, 0, 10, 1, 1);
            double expectedX = 1;
            double expectedY = 1;

            ball.Move();

            Assert.AreEqual(expectedX, ball.X);
            Assert.AreEqual(expectedY, ball.Y);
        }
    }

    [TestClass]
    public class BallManagerTests
    {
        [TestMethod]
        public void BallManager_AddBall_ShouldAddBallToList()
        {
            BallManager ballManager = new BallManager();
            Ball ball = new Ball(0, 0, 10, 1, 1);

            ballManager.AddBall(ball);

            Assert.AreEqual(1, ballManager.GetBallCount());
            CollectionAssert.Contains(ballManager.balls, ball);
        }

        [TestMethod]
        public void BallManager_UpdateBalls_ShouldRemoveBallsOutsideTable()
        {
            BallManager ballManager = new BallManager();
            Ball ballInside = new Ball(50, 50, 10, 1, 1);
            Ball ballOutside = new Ball(1050, 1050, 10, 1, 1);
            ballManager.AddBall(ballInside);
            ballManager.AddBall(ballOutside);

            ballManager.UpdateBalls();

            Assert.AreEqual(1, ballManager.GetBallCount());
            CollectionAssert.Contains(ballManager.balls, ballInside);
            CollectionAssert.DoesNotContain(ballManager.balls, ballOutside);
        }
    }
}
