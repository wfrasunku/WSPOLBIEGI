using System.ComponentModel;
using System.Diagnostics;
using Data;

namespace Logic
{
    public abstract class AbstractLogicApi
    {
        public abstract List<BallLogic> GetBalls();
        public abstract void AddBall();
        public abstract void RemoveBall();
        public abstract void StartUpdating(int numberOfBalls);

        public static AbstractLogicApi API(AbstractDataApi abstractDataApi = null) => new LogicApi(abstractDataApi);

        internal class LogicApi : AbstractLogicApi
        {
            private List<BallLogic> balls = new();
            private AbstractDataApi dataApi;

            public LogicApi(AbstractDataApi abstractDataApi = null)
            {
                if (abstractDataApi == null)
                {
                    this.dataApi = AbstractDataApi.API();
                }
                else
                {
                    this.dataApi = abstractDataApi;
                }
            }
            public override List<BallLogic> GetBalls() => this.balls;

            public override void StartUpdating(int numberOfBalls)
            {
                this.balls.Clear();
                this.dataApi.CreatePool(numberOfBalls);
                foreach (BallData ball in this.dataApi.GetBalls())
                {
                    this.balls.Add(new BallLogic(ball));
                    ball.PropertyChanged += CheckCollision;
                }
            }
            public override void AddBall()
            {
                Debug.WriteLine("a");
            }
            public override void RemoveBall()
            {
                Debug.WriteLine("b");
            }

            public void CheckCollision(object sender, PropertyChangedEventArgs e)
            {
                BallData ball = (BallData)sender;
                if (e.PropertyName == nameof(ball.X) || e.PropertyName == nameof(ball.Y))
                {
                    FieldCollision(ball);
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
                if ((ball.X + ball.Diameter) >= 780)
                {
                    ball.SetSpeed(-Math.Abs(ball.XSpeed), ball.YSpeed);
                    ball.X = 780 - ball.Diameter - 1;
                }
                if ((ball.Y + ball.Diameter) >= 380)
                {
                    ball.SetSpeed(ball.XSpeed, -Math.Abs(ball.YSpeed));
                    ball.Y = 380 - ball.Diameter - 1;
                }
            }
        }
    }
}

