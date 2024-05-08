using System.Collections.ObjectModel;
using System.ComponentModel;
using Model;

namespace ViewModel
{
    public class GenerateBalls : INotifyPropertyChanged
    {
        private ObservableCollection<BallModel> balls = new();
        private AbstractModelApi api;

        public RelayCommand AddBallCommand => new RelayCommand(
            execute =>
            {
                api.AddBall();
                this.Balls = api.GetBalls();
                OnPropertyChanged(nameof(Balls));
            });

        public RelayCommand RemoveBallCommand => new RelayCommand(
            execute =>
            {
                api.RemoveBall();
                this.Balls = api.GetBalls();
                OnPropertyChanged(nameof(Balls));
            }, canExecute => Balls != null);

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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public GenerateBalls() => this.api = AbstractModelApi.API();

        public ObservableCollection<BallModel> Balls
        {
            get { return balls; }
            set
            {
                if (balls != value)
                {
                    balls = value;
                    OnPropertyChanged(nameof(Balls));
                }
            }
        }
    }

}
