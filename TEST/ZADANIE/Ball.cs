namespace ZADANIE;

public class Ball
{
    public double X { get; private set; } // Położenie X kuli
    public double Y { get; private set; } // Położenie Y kuli
    public double Radius { get; private set; } // Promień kuli
    public double VelocityX { get; private set; } // Prędkość kuli w kierunku X
    public double VelocityY { get; private set; } // Prędkość kuli w kierunku Y

    public Ball(double x, double y, double radius, double velocityX, double velocityY)
    {
        X = x;
        Y = y;
        Radius = radius;
        VelocityX = velocityX;
        VelocityY = velocityY;
    }

    // Metoda do aktualizacji położenia kuli na podstawie jej prędkości
    public void Move()
    {
        X += VelocityX;
        Y += VelocityY;
    }
}

