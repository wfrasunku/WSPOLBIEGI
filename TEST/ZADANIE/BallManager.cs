using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ZADANIE;

public class BallManager
{
    public ObservableCollection<Ball> balls { get; private set; }
    private const int TableWidth = 1000; // Szerokość obszaru stołu
    private const int TableHeight = 600; // Wysokość obszaru stołu

    public BallManager()
    {
        balls = new ObservableCollection<Ball>();
    }

    // Metoda do dodawania nowej kuli
    public void AddBall(Ball ball)
    {
        balls.Add(ball);
    }

    // Metoda do aktualizacji położenia wszystkich kul
    public void UpdateBalls()
    {
        List<Ball> ballsToRemove = new List<Ball>();

        foreach (var ball in balls)
        {
            ball.Move(); // Aktualizacja położenia każdej kuli na podstawie jej prędkości

            // Sprawdzenie kolizji z krawędziami stołu
            if (ball.X - ball.Radius < 0 || ball.X + ball.Radius > TableWidth ||
                ball.Y - ball.Radius < 0 || ball.Y + ball.Radius > TableHeight)
            {
                ballsToRemove.Add(ball); // Dodaj kule do listy do usunięcia
            }
        }

        // Usuń kule, które opuściły obszar stołu
        foreach (var ballToRemove in ballsToRemove)
        {
            balls.Remove(ballToRemove);
        }
    }

    // Metoda do pobierania aktualnej liczby kul
    public int GetBallCount()
    {
        return balls.Count;
    }
}

