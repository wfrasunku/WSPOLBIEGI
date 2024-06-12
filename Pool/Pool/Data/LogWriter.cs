using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Data
{
    public class LogWriter
    {
        private readonly string logFilePath;

        public LogWriter()
        {
            logFilePath = $"logs-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.json";
        }

        public void WriteLogsToJSON(List<BallData> balls)
        {
            List<LogEntry> existingLogs = ReadLogsFromJSON();

            DateTime currentTime = DateTime.Now;

            foreach (var ball in balls)
            {
                LogEntry logEntry = new LogEntry
                {
                    Id = ball.Id,
                    PositionX = ball.X,
                    PositionY = ball.Y,
                    SpeedX = ball.XSpeed,
                    SpeedY = ball.YSpeed,
                    Diameter = ball.Diameter,
                    Color = ball.Color,
                    TimeStamp = currentTime.ToString("dd-MM-yyyy HH:mm:ss")
                };
                existingLogs.Add(logEntry);
            }
            WriteLogsToFile(existingLogs);
        }

        private List<LogEntry> ReadLogsFromJSON()
        {
            if (File.Exists(logFilePath))
            {
                string json = File.ReadAllText(logFilePath);
                return JsonSerializer.Deserialize<List<LogEntry>>(json) ?? new List<LogEntry>();
            }
            else
            {
                return new List<LogEntry>();
            }
        }

        private void WriteLogsToFile(List<LogEntry> logs)
        {
            string json = JsonSerializer.Serialize(logs, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(logFilePath, json);
        }
    }

    public class LogEntry
    {
        public int Id { get; set; }
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public double SpeedX { get; set; }
        public double SpeedY { get; set; }
        public int Diameter { get; set; }
        public string Color { get; set; }
        public string TimeStamp { get; set; }
    }
}
