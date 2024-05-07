﻿using DataLayer;
using System;
using System.Collections.ObjectModel;
using TP.ConcurrentProgramming.Model;
using TP.ConcurrentProgramming.ViewModel.MVVMLight;

namespace TP.ConcurrentProgramming.ViewModel
{
    public class MainWindowViewModel : ViewModelBase, IDisposable
    {
        private ModelAbstractApi ModelLayer;

        public ObservableCollection<IBall> Balls { get; } = new ObservableCollection<IBall>();

        public RelayCommand AddBallCommand => new RelayCommand(execute => ModelLayer.AddBall());
        public RelayCommand RemoveBallCommand => new RelayCommand(execute => ModelLayer.RemoveBall(), canExecute => Balls != null);

        public MainWindowViewModel()
        {
            ModelLayer = ModelAbstractApi.CreateApi();
            IDisposable observer = ModelLayer.Subscribe<IBall>(x => { if (Balls.Contains(x)) { Balls.Remove(x); return; } Balls.Add(x); });
        }

        public RelayCommand StartCommand => new RelayCommand(
            execute =>
            {
                String str = execute as String;
                if (uint.TryParse(str, out uint value)) { ModelLayer.Start((int)value); }
            });

        public void Dispose()
        {
            ModelLayer.Dispose();
        }
    }
}