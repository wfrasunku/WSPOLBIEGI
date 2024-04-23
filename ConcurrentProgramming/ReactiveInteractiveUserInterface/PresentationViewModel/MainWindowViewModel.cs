﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TP.ConcurrentProgramming.PresentationModel;
using TP.ConcurrentProgramming.PresentationViewModel.MVVMLight;
using static System.Net.Mime.MediaTypeNames;

namespace TP.ConcurrentProgramming.PresentationViewModel
{
  public class MainWindowViewModel : ViewModelBase, IDisposable
  {
        #region public API

        public MainWindowViewModel()
        {
            ModelLayer = ModelAbstractApi.CreateApi();
            IDisposable observer = ModelLayer.Subscribe<IBall>(x =>{ if (Balls.Contains(x)) { Balls.Remove(x); return; } Balls.Add(x); });
            
        }

        public ObservableCollection<IBall> Balls { get; } = new ObservableCollection<IBall>();

        public RelayCommand StartCommand => new RelayCommand(
            execute => {
                String str = execute as String;
                if (uint.TryParse(str, out uint value)) {ModelLayer.Start((int)value);}
                });

        public RelayCommand AddBallCommand => new RelayCommand(execute => ModelLayer.AddBall());
        public RelayCommand RemoveBallCommand => new RelayCommand(execute => ModelLayer.RemoveBall(), canExecute => Balls != null);

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