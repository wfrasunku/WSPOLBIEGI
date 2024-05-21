using Timer = System.Timers.Timer;

namespace Data
{
    internal class MoveTimer
    {
        private Timer moveTimer;
        private List<BallData> balls;

        public MoveTimer(List<BallData> balls)
        {
            this.balls = balls;
            SetTimer();
        }

        private void SetTimer()
        {
            moveTimer = new Timer(100);
            moveTimer.AutoReset = true;
            moveTimer.Enabled = true;
        }

        public void StopTimer()
        {
            moveTimer.Stop();
        }
    }
}
