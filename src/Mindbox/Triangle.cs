namespace Mindbox;

public class Triangle : IShape
{
    private readonly (int a, int b, int c) _sides;

    public Triangle((int a, int b, int c) sides)
    {
        _sides = sides;
    }

    public double Area()
    {
        return 0;
    }
}
