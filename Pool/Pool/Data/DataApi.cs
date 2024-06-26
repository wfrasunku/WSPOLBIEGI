﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public abstract class AbstractDataApi
    {
        public abstract void CreatePool(int numberOfBalls, int height, int width);
        public abstract List<BallData> GetBalls();
        public static AbstractDataApi API() => new DataApi();
        public abstract PoolTable PoolTable { get; }

        public class DataApi : AbstractDataApi
        {
            private PoolTable table;
            private MoveTimer moveTimer;
            private bool updating;
            private readonly object positionLock = new();
            private List<BallData> balls = new List<BallData>();

            public override PoolTable PoolTable => table;

            public override void CreatePool(int numberOfBalls, int height, int width)
            {
                table = new PoolTable(height, width);

                if (updating)
                {
                    moveTimer.StopTimer();
                }

                CreateBalls(numberOfBalls, height, width);
                updating = true;
                balls = GetBalls();

                LogWriter logWriter = new LogWriter();
                moveTimer = new MoveTimer(balls, logWriter);

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
                            await Task.Delay(15);
                        }
                    });
                    task.Start();
                }
            }

            public static BallData CreateBall(int height, int width, string color = null)
            {
                Random r = new Random();

                double x = r.Next(100, width - 100);
                double y = r.Next(100, height - 100);

                double xSpeed = 0;
                double ySpeed = 0;

                while (xSpeed == 0)
                {
                    xSpeed = r.Next(-5, 6);
                }

                while (ySpeed == 0)
                {
                    ySpeed = r.Next(-5, 6);
                }

                //int diameter = r.Next(15, 25);
                color = SetColor(color);

                BallData createdBall = new BallData(x, y, 20, 3, color);
                createdBall.SetSpeed(xSpeed, ySpeed);
                return createdBall;
            }

            public static string SetColor(string color = null)
            {
                if (!string.IsNullOrEmpty(color))
                {
                    return color;
                }

                Random r = new Random();
                double n = r.Next(1, 9);

                return n switch
                {
                    1 => "Yellow",
                    2 => "Blue",
                    3 => "Red",
                    4 => "Purple",
                    5 => "Orange",
                    6 => "Green",
                    7 => "Brown",
                    _ => "Black",
                };
            }

            public void CreateBalls(int numberOfBalls, int height, int width)
            {
                balls.Clear();
                BallData.ResetIdCounter();
                if (File.Exists("logs.json"))
                {
                    File.Delete("logs.json");
                }

                for (int i = 0; i < numberOfBalls; i++)
                {
                    balls.Add(CreateBall(height, width));
                }
                LogWriter logWriter = new LogWriter();
                logWriter.WriteLogsToJSON(balls);
            }

            public override List<BallData> GetBalls() => new List<BallData>(balls);
        }
    }
}
