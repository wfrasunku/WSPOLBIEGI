using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void Stop()
        {
            moveTimer.Stop();
        }
    }
}
