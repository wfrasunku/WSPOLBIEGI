using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

namespace Data
{
    internal class MoveTimer
    {
        private System.Timers.Timer moveTimer;
        private readonly List<BallData> balls;
        private readonly LogWriter logWriter;

        public MoveTimer(List<BallData> balls, LogWriter logWriter)
        {
            this.balls = balls;
            this.logWriter = logWriter;
            SetTimer();
        }

        private void SetTimer()
        {
            moveTimer = new System.Timers.Timer(1000);
            moveTimer.Elapsed += (sender, e) => WriteLogs();
            moveTimer.AutoReset = true;
            moveTimer.Enabled = true;
        }

        private void WriteLogs()
        {
            logWriter.WriteLogsToJSON(balls);
        }

        public void StopTimer()
        {
            moveTimer.Stop();
        }
    }
}
