using System;
using System.ComponentModel;

namespace TP.ConcurrentProgramming.DataModel
{
    public interface IBall : INotifyPropertyChanged
    {
        double Top { get; }
        double Left { get; }
        double Diameter { get; }
    }

    public class BallChangeEventArgs : EventArgs
    {
        public IBall Ball { get; internal set; }
    }
}