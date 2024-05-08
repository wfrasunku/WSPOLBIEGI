using System.Collections.ObjectModel;
using System.ComponentModel;
using Model;

namespace ViewModel
{
    public class GenerateBalls : INotifyPropertyChanged
    {
        private ObservableCollection<Ball> balls = new();
        private AbstractModelApi api;

        public RelayCommand AddBallCommand => new RelayCommand(execute => api.AddBall());
        public RelayCommand RemoveBallCommand => new RelayCommand(execute => api.RemoveBall(), canExecute => Balls != null);
        public RelayCommand StartMoveCommand => new RelayCommand(
            execute =>
            {
                String str = execute as String;
                if (uint.TryParse(str, out uint value)) { this.api.Start((int)value); }
                this.Balls = api.GetBalls();
            });

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public GenerateBalls() => this.api = AbstractModelApi.API();

        public ObservableCollection<Ball> Balls
        {
            get { return balls; }
            set
            {
                if (balls != value)
                {
                    balls = value;
                    OnPropertyChanged(nameof(balls));
                }
            }
        }
    }

}
