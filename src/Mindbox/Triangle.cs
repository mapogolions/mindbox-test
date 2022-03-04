namespace Mindbox;

public class Triangle : IShape
{
    private readonly (double a, double b, double c) _sides;

    public Triangle((double a, double b, double c) sides)
    {
        Sides = sides;
    }

    public Triangle(double a, double b, double c) : this((a, b, c)) { }

    public bool IsRight() =>
        Math.Pow(_sides.a, 2) + Math.Pow(_sides.b, 2) == Math.Pow(_sides.c, 2) ||
        Math.Pow(_sides.a, 2) + Math.Pow(_sides.c, 2) == Math.Pow(_sides.b, 2) ||
        Math.Pow(_sides.b, 2) + Math.Pow(_sides.c, 2) == Math.Pow(_sides.a, 2);

    public (double a, double b, double c) Sides
    {
        get => _sides;

        private init
        {
            var (a, b, c) = value;
            if (a < 0 || b < 0 || c < 0)
                throw new ArgumentOutOfRangeException(nameof(Sides));
            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException($"Impossible triangle: {nameof(Sides)}");
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
