using DataLayer;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LogicLayer
{
    public class ModelBall : IBall, IDisposable
    {
        private double TopBackingField;
        private double LeftBackingField;
        private Timer MoveTimer;
        private Random Random = new Random();

        public double Diameter { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ModelBall(double top, double left)
        {
            TopBackingField = top;
            LeftBackingField = left;
            MoveTimer = new Timer(Move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(50));
        }

        public double Top
        {
            get { return TopBackingField; }
            private set
            {
                if (TopBackingField == value)
                    return;
                TopBackingField = value;
                RaisePropertyChanged();
            }
        }

        public double Left
        {
            get { return LeftBackingField; }
            private set
            {
                if (LeftBackingField == value)
                    return;
                LeftBackingField = value;
                RaisePropertyChanged();
            }
        }

        public void Dispose()
        {
            MoveTimer.Dispose();
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Move(object state)
        {
            if (state != null)
                throw new ArgumentOutOfRangeException(nameof(state));
            double randTop = (Random.NextDouble() - 0.5) * 20;
            Top = Top + randTop;
            double randLeft = (Random.NextDouble() - 0.5) * 35;
            Left = Left + randLeft;

            if (Top < 0 || Top > 360)
                Top = Top - randTop;

            if (Left < 0 || Left > 760)
                Left = Left - randLeft;
        }
    }
}
