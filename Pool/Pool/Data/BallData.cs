using System.ComponentModel;

namespace Data
{
    public class BallData : INotifyPropertyChanged
    {
        private static int nextId = 1;

        private readonly int id;
        private double mass;
        private string color;
        private double x;
        private double y;
        private int diameter;
        private double xSpeed;
        private double ySpeed;

        public BallData(double x, double y, int diameter, double mass, string color)
        {
            this.id = nextId++;
            this.mass = mass;
            this.x = x;
            this.y = y;
            this.diameter = diameter;
            this.color = color;
        }

        public int Id => id;

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public double Mass 
        {
            get { return mass; }
        }

        public string Color
        {
            get { return color; }
        }

        public int Diameter
        {
            get { return diameter; }
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


        public double XSpeed
        {
            get { return xSpeed; }
            set
            {
                if (xSpeed != value)
                {
                    xSpeed = value;
                    OnPropertyChanged(nameof(XSpeed));
                }
            }
        }

        public double YSpeed
        {
            get { return ySpeed; }
            set
            {
                if (ySpeed != value)
                {
                    ySpeed = value;
                    OnPropertyChanged(nameof(YSpeed));
                }
            }
        }

        public void SetSpeed(double x, double y)
        {
            if (x > 20 || y > 20)
            {
                x = 2;
                y = 2;
            }
            XSpeed = x;
            YSpeed = y;
        }

        public void ActualPosition(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
