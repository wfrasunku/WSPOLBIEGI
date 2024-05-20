using System.Diagnostics;
using System.Drawing;
using System.Linq.Expressions;
using System.Threading.Tasks;


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
            private MoveTimer moveTimer;
            private bool updating;
            private readonly object positionLock = new();

            public override void CreatePool(int numberOfBalls)
            {
                CreateBalls(numberOfBalls);
                updating = true;
                List<BallData> balls = GetBalls();
                moveTimer = new MoveTimer(balls);
  
                foreach (BallData ball in balls)
                {
                    Task task = new Task(async () =>
                    {
                        while (updating)
                        {
                            lock (positionLock)
                            {
                                ball.ActualPosition(ball.X + ball.XSpeed, ball.Y + ball.YSpeed);
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

                double xSpeed = 0;
                double ySpeed = 0;

                while(xSpeed == 0)
                {
                    xSpeed = r.Next(-5, 6);
                }

                while(ySpeed == 0)
                {
                    ySpeed = r.Next(-5, 6);
                }

                string color;
                double n = r.Next(1, 9);
                if (n == 1)
                {
                    color = "Yellow";
                }
                else if (n == 2)
                {
                    color = "Blue";
                }
                else if(n == 3)
                {
                    color = "Red";
                }
                else if (n == 4)
                {
                    color = "Purple";
                }
                else if (n == 5)
                {
                    color = "Orange";
                }
                else if (n == 6)
                {
                    color = "Green";
                }
                else if (n == 7)
                {
                    color = "Brown";
                }
                else
                {
                    color = "Black";
                }


                BallData createdBall = new BallData(x, y, 20, color, 3);

                createdBall.SetSpeed(xSpeed, ySpeed);
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
