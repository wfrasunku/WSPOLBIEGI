using System.ComponentModel;
using Data;

namespace Logic
{
    public abstract class AbstractLogicApi
    {
        public abstract List<BallLogic> GetBalls();
        public abstract void StartUpdating(int numberOfBalls);

        public static AbstractLogicApi API(AbstractDataApi abstractDataApi = null) => new LogicApi(abstractDataApi);

        internal class LogicApi : AbstractLogicApi
        {
            private readonly object speedLock = new object();
            private List<BallLogic> balls = new();
            private PoolTable table;
            private AbstractDataApi dataApi;

            public LogicApi(AbstractDataApi abstractDataApi = null)
            {
                this.dataApi = abstractDataApi ?? AbstractDataApi.API();
            }
            public override List<BallLogic> GetBalls() => this.balls;

            public override void StartUpdating(int numberOfBalls)
            {
                foreach (BallData ball in this.dataApi.GetBalls())
                {
                    ball.PropertyChanged -= CheckCollision;
                }
                this.balls.Clear();
                this.dataApi.CreatePool(numberOfBalls, 380, 780);
                foreach (BallData ball in this.dataApi.GetBalls())
                {
                    this.balls.Add(new BallLogic(ball));
                    ball.PropertyChanged += CheckCollision;
                }
            }

            public void CheckCollision(object sender, PropertyChangedEventArgs e)
            {
                BallData ball = (BallData)sender;
                if (e.PropertyName == nameof(ball.X) || e.PropertyName == nameof(ball.Y))
                {
                    FieldCollision(ball);
                    BallCollision(ball);
                }
            }

            private void FieldCollision(BallData ball)
            {
                if (ball.X <= 0)
                {
                    ball.SetSpeed(Math.Abs(ball.XSpeed), ball.YSpeed);
                    ball.X = 1;
                }
                if (ball.Y <= 0)
                {
                    ball.SetSpeed(ball.XSpeed, Math.Abs(ball.YSpeed));
                    ball.Y = 1;
                }
                if ((ball.X + ball.Diameter) >= this.dataApi.PoolTable.Width)
                {
                    ball.SetSpeed(-Math.Abs(ball.XSpeed), ball.YSpeed);
                    ball.X = 780 - ball.Diameter - 1;
                }
                if ((ball.Y + ball.Diameter) >= this.dataApi.PoolTable.Height)
                {
                    ball.SetSpeed(ball.XSpeed, -Math.Abs(ball.YSpeed));
                    ball.Y = 380 - ball.Diameter - 1;
                }
            }

            private void BallCollision(BallData ball)
            {
                foreach (BallData nextBall in dataApi.GetBalls())
                {
                    if (nextBall == ball) continue;

                    double dx = (ball.X + ball.Diameter / 2 + ball.XSpeed) - (nextBall.X + nextBall.Diameter / 2 + nextBall.XSpeed);
                    double dy = (ball.Y + ball.Diameter / 2 + ball.YSpeed) - (nextBall.Y + nextBall.Diameter / 2 + nextBall.YSpeed);
                    double distance = Math.Pow(dx * dx + dy * dy, 0.5);
                    if (distance <= (ball.Diameter / 2) + (nextBall.Diameter / 2))
                    {
                        double nx = dx / distance;
                        double ny = dy / distance;

                        double vx = ball.XSpeed - nextBall.XSpeed;
                        double vy = ball.YSpeed - nextBall.YSpeed;

                        double p = 2 * (vx * nx + vy * ny) / (ball.Mass + nextBall.Mass);

                        lock (speedLock)
                        {
                            ball.SetSpeed(ball.XSpeed - p * nextBall.Mass * nx, ball.YSpeed - p * nextBall.Mass * ny);
                            nextBall.SetSpeed(nextBall.XSpeed + p * ball.Mass * nx, nextBall.YSpeed + p * ball.Mass * ny);
                        }
                    }
                }
            }
        }
    }
}

