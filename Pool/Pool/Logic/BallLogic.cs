using System.ComponentModel;
using Data;

namespace Logic
{
    public class BallLogic : INotifyPropertyChanged
    {
        private BallData ball;
        private PoolTable table;

        public BallLogic(BallData ball)
        {
            this.ball = ball;
            this.ball.PropertyChanged += Update;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Update(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ball.X))
            {
                OnPropertyChanged(nameof(ball.X));
            }
            else if (e.PropertyName == nameof(ball.Y))
            {
                OnPropertyChanged(nameof(ball.Y));
            }
            else if (e.PropertyName == nameof(ball.Diameter))
            {
                OnPropertyChanged(nameof(ball.Diameter));
            }
        }

        public double X
        {
            get { return ball.X; }
            set
            {
                if (ball.X != value)
                {
                    ball.X = value;
                    OnPropertyChanged(nameof(ball.X));
                }
            }
        }

        public double Y
        {
            get { return ball.Y; }
            set
            {
                if (ball.Y != value)
                {
                    ball.Y = value;
                    OnPropertyChanged(nameof(ball.Y));
                }
            }
        }
        public double Mass
        {
            get { return ball.Mass; }
        }

        public string Color
        {
            get { return ball.Color; }
        }

        public double Diameter
        {
            get { return ball.Diameter; }
        }

        public int Height
        {
            get { return table.Height; }
        }

        public int Width
        {
            get { return table.Width; }
        }

        public double XSpeed
        { 
            get { return ball.XSpeed; } 
        }

        public double YSpeed
        { 
            get { return ball.YSpeed; } 
        }

        public void SetSpeed(double xSpeed, double ySpeed)
        {
            ball.SetSpeed(xSpeed, ySpeed);

        }
    }
}

