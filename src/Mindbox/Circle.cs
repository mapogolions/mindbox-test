namespace Mindbox;

public class Circle : IShape
{
    private readonly double _radius;

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Radius
    {
        get => _radius;

        private init
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(Radius));
            _radius = value;
        }
    }

    public double Area()
    {
        return Math.PI * Math.Pow(_radius, 2);
    }
}
