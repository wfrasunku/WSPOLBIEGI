using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace TP.ConcurrentProgramming.PresentationModel
{
  internal class ModelBall : IBall, IDisposable
  {
    public ModelBall(double top, double left)
    {
      TopBackingField = top;
      LeftBackingField = left;
      MoveTimer = new Timer(Move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(100));
    }

    #region IBall

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

    public double Diameter { get; internal set; }

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion INotifyPropertyChanged

    #endregion IBall

    #region IDisposable

    public void Dispose()
    {
      MoveTimer.Dispose();
    }

    #endregion IDisposable

    #region private


    private double TopBackingField;
    private double LeftBackingField;
    private Timer MoveTimer;
    private Random Random = new Random();

    private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void Move(object state)
    {
      if (state != null)
        throw new ArgumentOutOfRangeException(nameof(state));
      double newTop = Top + (Random.NextDouble() - 0.5) * 5;
      double newLeft = Left + (Random.NextDouble() - 0.5) * 15;

            if (newTop < 5 || newTop > 395)
                newTop = Top * -1 * (Random.NextDouble() - 0.5) * 5;

            if (newLeft < 5 || newLeft > 795)
                newLeft = Left * -1 * (Random.NextDouble() - 0.5) * 15;

            if (newTop >= 0 && newTop <= 400 && newLeft >= 0 && newLeft <= 800)
            {
                Top = newTop;
                Left = newLeft;
            }
        }

    #endregion private
  }
}