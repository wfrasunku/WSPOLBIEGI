using Data;
using Logic;
using Presentation.Commands;
using Presentation.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class MainViewModel : Model.MainModel
    {
        private BallGenerator ballGenerator;

        private int _numberOfBalls;
        public int NumberOfBalls
        {
            get { return _numberOfBalls; }
            set
            {
                if (_numberOfBalls != value)
                {
                    _numberOfBalls = value;
                    OnPropertyChanged(nameof(NumberOfBalls));
                }
            }
        }

        private ObservableCollection<Ball> _balls;
        public ObservableCollection<Ball> Balls
        {
            get { return _balls; }
            set
            {
                _balls = value;
                OnPropertyChanged(nameof(Balls));
            }
        }

        public ICommand GenerateBallsCommand { get; private set; }

        public MainViewModel()
        {
            ballGenerator = new BallGenerator();
            GenerateBallsCommand = new RelayCommand(GenerateBalls);
        }

        public void GenerateBalls(object parameter)
        {
            Balls = new ObservableCollection<Ball>(ballGenerator.GenerateBalls(NumberOfBalls));
            Debug.WriteLine("Dodano {0} kule", NumberOfBalls);
        }
    }
    }
