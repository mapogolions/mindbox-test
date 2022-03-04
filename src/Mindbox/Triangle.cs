namespace Mindbox;

public class Triangle : IShape
{
    private readonly (double a, double b, double c) _sides;

    public Triangle((double a, double b, double c) sides)
    {
        Sides = sides;
    }

    public (double a, double b, double c) Sides
    {
        get => _sides;

        private init
        {
            if (value.a < 0 || value.b < 0 || value.c < 0)
                throw new ArgumentOutOfRangeException($"Impossible triangle: {nameof(Sides)}");
            _sides = value;
        }
    }

    public double Area()
    {
        var (a, b, c) = _sides;
        var semiPerimeter = (a + b + c) / 2;
        return Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
    }
}
