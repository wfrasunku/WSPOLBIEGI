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
            moveTimer = new System.Timers.Timer(1000); // Ustawienie interwału na 1000 ms (1 sekundę)
            moveTimer.Elapsed += (sender, e) => WriteLogs(); // Ustawienie zdarzenia Elapsed, które wywoła metodę WriteLogs co określony czas
            moveTimer.AutoReset = true;
            moveTimer.Enabled = true;
        }

        private void WriteLogs()
        {
            // Zapis danych do pliku JSON
            logWriter.WriteLogsToJSON(balls);
        }

        public void StopTimer()
        {
            moveTimer.Stop();
        }
    }
}
