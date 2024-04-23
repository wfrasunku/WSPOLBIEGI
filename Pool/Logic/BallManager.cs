using Data;

namespace Logic
{
    public class BallGenerator
    {
        private const double TableWidth = 800;
        private const double TableHeight = 400;

        public List<Ball> GenerateBalls(int numberOfBalls)
        {
            Random random = new Random();
            List<Ball> balls = new List<Ball>();

            for (int i = 0; i < numberOfBalls; i++)
            {
                balls.Add(new Ball
                {
                    Position = new System.Drawing.Point((int)(random.NextDouble() * TableWidth), (int)(random.NextDouble() * TableHeight))
                });
            }

            return balls;
        }
    }
}
