using System.ComponentModel;
using System.Runtime.CompilerServices;
using TP.ConcurrentProgramming.DataModel;

namespace TP.ConcurrentProgramming.Logic
{
    internal class ModelBall : IBall, IDisposable
    {
        private double top;
        private double left;
        private Timer moveTimer;
        private Random random = new Random();

        public ModelBall(double top, double left)
        {
            this.top = top;
            this.left = left;
            Diameter = 20;
            moveTimer = new Timer(Move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(50));
        }

        public double Top
        {
            get { return top; }
            private set
            {
                if (top == value)
                    return;
                top = value;
                RaisePropertyChanged();
            }
        }

        public double Left
        {
            get { return left; }
            private set
            {
                if (left == value)
                    return;
                left = value;
                RaisePropertyChanged();
            }
        }

        public double Diameter { get; internal set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Dispose()
        {
            moveTimer.Dispose();
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Move(object state)
        {
            if (state != null)
                throw new ArgumentOutOfRangeException(nameof(state));

            double randTop = (random.NextDouble() - 0.5) * 10;
            Top += randTop;

            double randLeft = (random.NextDouble() - 0.5) * 25;
            Left += randLeft;

            if (Top < 0 || Top > 360)
                Top -= randTop;

            if (Left < 0 || Left > 760)
                Left -= randLeft;
        }
    }
}
