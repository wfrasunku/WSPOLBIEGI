using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace TP.ConcurrentProgramming.PresentationModel
{
    public interface IBall : INotifyPropertyChanged
    {
        double Top { get; }
        double Left { get; }
        double Diameter { get; }
    }

    public class BallChaneEventArgs : EventArgs
    {
        public IBall Ball { get; internal set; }
    }

    public abstract class ModelAbstractApi : IObservable<IBall>, IDisposable
    {
        public abstract void AddBall();
        public abstract void Start(int ballNumber);
        public abstract void RemoveBall();
        public abstract IDisposable Subscribe(IObserver<IBall> observer);
        public abstract void Dispose();

        public static ModelAbstractApi CreateApi()
        {
            PresentationModel model = new PresentationModel();
            return model;
        }
    }
}