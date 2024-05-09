using System.Diagnostics;
using System.Drawing;
using Timer = System.Timers.Timer;

namespace Data
{
    public abstract class AbstractDataApi
    {
        public abstract void CreatePool(int numberOfBalls);
        public abstract void AddBall();
        public abstract void RemoveBall();
        public abstract List<BallData> GetBalls();
        private readonly List<BallData> balls = new();
        public static AbstractDataApi API() => new DataApi();

        public class DataApi : AbstractDataApi
        {
            private Timer MoveTimer;
            private bool updating;
            private readonly object positionLock = new();

            public override void CreatePool(int numberOfBalls)
            {
                CreateBalls(numberOfBalls);
                updating = true;
                List<BallData> balls = GetBalls();
  
                foreach (BallData ball in balls)
                {
                    MoveTimer = new Timer(100);
                    Task task = new Task(async () =>
                    {
                        while (updating)
                        {
                            lock (positionLock)
                            {
                                ball.X += ball.XSpeed;
                                ball.Y += ball.YSpeed;
                            }
                            await Task.Delay(5);
                        }
                    });
                    task.Start();
                }
            }

            public override void AddBall()
            {
                this.balls.Add(CreateBall());
                Debug.WriteLine(balls.Count);
            }

            public override void RemoveBall()
            {
                if (balls.Count > 0)
                {
                    balls.RemoveAt(balls.Count - 1);
                }
                Debug.WriteLine(balls.Count);
            }

            public static BallData CreateBall()
            {
                Random r = new Random();

                double x = r.Next(100, 800 - 100);
                double y = r.Next(100, 400 - 100);

                double xSpeed = r.Next(-1, 2);
                double ySpeed = r.Next(-1, 2);

                double newXSpeed = (xSpeed == 0) ? -1 : 1;
                double newYSpeed = (ySpeed == 0) ? 1 : -1;

                string color;
                double n = r.Next(1, 4);
                if (n == 1)
                {
                    color = "Magenta";
                }
                else if (n == 2)
                {
                    color = "Blue";
                }
                else
                {
                    color = "Black";
                }

                BallData createdBall = new BallData(x, y, 30, color);

                createdBall.SetSpeed(newXSpeed, newYSpeed);
                return createdBall;
            }

            public void CreateBalls(int numberOfBalls)
            {
                this.balls.Clear();
                for (int i = 0; i < numberOfBalls; i++)
                {
                    this.balls.Add(CreateBall());
                }
            }
            public override List<BallData> GetBalls() => new List<BallData>(balls);
        }
    }
}
