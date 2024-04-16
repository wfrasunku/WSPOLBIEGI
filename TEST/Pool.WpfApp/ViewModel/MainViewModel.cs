using Pool.WpfApp.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pool.WpfApp.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private int _NumberOfBalls;

        public MainViewModel()
        {
            StartPoolCommands = new RelayCommand(ExecuteStartPoolCommand);
        }

        public ICommand StartPoolCommands { get; private set; }

        public int NumberOfBalls
        {
            get { return _NumberOfBalls; }
            set
            {
                if (_NumberOfBalls != value)
                {
                    _NumberOfBalls = value;
                    OnPropertyChanged();
                }
            }
        }

        private void GenerateBalls(int numberOfBalls)
        {
            // Tutaj generujesz odpowiednią liczbę kul na stole
            Console.WriteLine($"Generowanie {numberOfBalls} kulek na stole...");
        }

        private void ExecuteStartPoolCommand(object parameter)
        {
            // Tutaj możesz wykonać odpowiednie działania na podstawie wpisanej liczby kul
            GenerateBalls(NumberOfBalls);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
