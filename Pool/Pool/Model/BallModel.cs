using System.ComponentModel;
using Logic;

namespace Model
{
    public class BallModel : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double diameter;
        private string color;
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public double X
        {
            get { return x; }
            set
            {
                if (x != value)
                {
                    x = value;
                    OnPropertyChanged(nameof(X));
                }
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                if (y != value)
                {
                    y = value;
                    OnPropertyChanged(nameof(Y));
                }
            }
        }

        public string Color
        {
            get { return color; }
            set
            {
                if (color != value)
                {
                    color = value;
                    OnPropertyChanged(nameof(Color));
                }
            }
        }

        public double Diameter
        {
            get { return diameter; }
            set
            {
                if (diameter != value)
                {
                    diameter = value;
                    OnPropertyChanged(nameof(Diameter));
                }
            }
        }

        public BallModel(BallLogic ball)
        {
            this.x = ball.X;
            this.y = ball.Y;
            this.diameter = ball.Diameter;
            this.color = ball.Color;
            ball.PropertyChanged += Move;
        }

        private void Move(object sender, PropertyChangedEventArgs e)
        {
            BallLogic ball = (BallLogic)sender;
            if (e.PropertyName == nameof(ball.X))
            {
                this.X = ball.X;

            }
            if (e.PropertyName == nameof(ball.Y))
            { this.Y = ball.Y; }
        }
    }
}