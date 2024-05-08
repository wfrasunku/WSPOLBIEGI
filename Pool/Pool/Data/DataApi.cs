﻿using Timer = System.Timers.Timer;

namespace Data
{
    public abstract class AbstractDataApi
    {
        public abstract void CreatePool(int numberOfBalls);
        public abstract List<BallData> GetBalls();
        private readonly List<BallData> balls = new();
        public static AbstractDataApi API() => new DataApi();

        internal class DataApi : AbstractDataApi
        {
            private Timer MoveTimer;
            private bool updating;
            private readonly object positionLock = new();

            public override void CreatePool(int numberOfBalls)
            {
                CreateBalls(numberOfBalls);
                updating = true;
                List<BallData> balls = GetBalls();
                MoveTimer = new Timer(100);


                foreach (BallData ball in balls)
                {
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
            public BallData CreateBall()
            {
                Random r = new Random();

                double x = r.Next(100, 800 - 100);
                double y = r.Next(100, 400 - 100);

                double xSpeed = r.Next(-1, 2);
                double ySpeed = r.Next(-1, 2);

                double newXSpeed = (xSpeed == 0) ? -1 : 1;
                double newYSpeed = (ySpeed == 0) ? 1 : -1;

                BallData createdBall = new BallData(x, y, 15);

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
