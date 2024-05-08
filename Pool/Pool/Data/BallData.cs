﻿using System.ComponentModel;

namespace Data
{
    public class BallData : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double diameter;
        private double xSpeed;
        private double ySpeed;

        public BallData(double x, double y, int diameter)
        {
            this.x = x;
            this.y = y;
            this.diameter = diameter;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
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
            XSpeed = x;
            YSpeed = y;
        }
    }
}
