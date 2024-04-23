using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TP.ConcurrentProgramming.PresentationModel;
using TP.ConcurrentProgramming.PresentationViewModel.MVVMLight;

namespace TP.ConcurrentProgramming.PresentationViewModel
{
  public class MainWindowViewModel : ViewModelBase, IDisposable
  {
        #region public API

        public MainWindowViewModel()
        {
            ModelLayer = ModelAbstractApi.CreateApi();
            IDisposable observer = ModelLayer.Subscribe<IBall>(x => Balls.Add(x));
            ModelLayer.Start();
        }

        public ObservableCollection<IBall> Balls { get; } = new ObservableCollection<IBall>();

        public RelayCommand AddBallCommand => new RelayCommand(execute => ModelLayer.AddBall());

        #endregion public API

        #region IDisposable

        public void Dispose()
    {
      ModelLayer.Dispose();
    }

    #endregion IDisposable

        #region private

    private ModelAbstractApi ModelLayer;

    #endregion private
  }
}