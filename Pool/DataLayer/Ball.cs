using System.ComponentModel;

namespace DataLayer
{
    public interface IBall : INotifyPropertyChanged
    {
        double Top { get; }
        double Left { get; }
        double Diameter { get; }
    }
    public class Ball : IBall
    {
        public double Top => throw new NotImplementedException();

        public double Left => throw new NotImplementedException();

        public double Diameter => throw new NotImplementedException();

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
