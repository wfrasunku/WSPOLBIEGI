using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZADANIE;

namespace ZADANIE_TEST
{
    [TestClass]
    public class BallTests
    {
        [TestMethod]
        public void Ball_Move_ShouldUpdatePosition()
        {
            // Arrange
            Ball ball = new Ball(0, 0, 10, 1, 1);
            double expectedX = 1;
            double expectedY = 1;

            // Act
            ball.Move();

            // Assert
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
            // Arrange
            BallManager ballManager = new BallManager();
            Ball ball = new Ball(0, 0, 10, 1, 1);

            // Act
            ballManager.AddBall(ball);

            // Assert
            Assert.AreEqual(1, ballManager.GetBallCount());
            CollectionAssert.Contains(ballManager.balls, ball);
        }

        [TestMethod]
        public void BallManager_UpdateBalls_ShouldRemoveBallsOutsideTable()
        {
            // Arrange
            BallManager ballManager = new BallManager();
            Ball ballInside = new Ball(50, 50, 10, 1, 1);
            Ball ballOutside = new Ball(1050, 1050, 10, 1, 1);
            ballManager.AddBall(ballInside);
            ballManager.AddBall(ballOutside);

            // Act
            ballManager.UpdateBalls();

            // Assert
            Assert.AreEqual(1, ballManager.GetBallCount());
            CollectionAssert.Contains(ballManager.balls, ballInside);
            CollectionAssert.DoesNotContain(ballManager.balls, ballOutside);
        }
    }
}
