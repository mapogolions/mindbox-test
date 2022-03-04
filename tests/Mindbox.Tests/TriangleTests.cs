using System;
using Xunit;

namespace Mindbox.Tests;

public class TriangleTest
{
    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(4, 3, 5)]
    [InlineData(5, 3, 4)]
    [InlineData(5, 4, 3)]
    public void IsRightTriangleShouldBeOrderAgnostic(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        Assert.True(triangle.IsRight());
    }

    [Theory]
    [InlineData(6.3, 6.8, 7.8)]
    public void ShouldReturnFalseIfTriangleIsNotRight(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        Assert.False(triangle.IsRight());
    }

    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(18, 30, 24)]
    public void ShouldReturnTrueIfTriangleIsRight(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        Assert.True(triangle.IsRight());
    }

    [Theory]
    [InlineData(3, 6, 7, 8.94)]
    [InlineData(1, 1, 1, 0.43)]
    public void ShouldCalculateTriangleArea(double a, double b, double c, double area)
    {
        var triangle = new Triangle((a, b, c));
        Assert.Equal(area, triangle.Area(), precision: 2);
    }

    [Theory]
    [InlineData(-1, 0, 0)]
    [InlineData(0, -1, 0)]
    [InlineData(0, 0, -1)]
    public void ShouldThrowExceptionIfAtLeastOneSideIsLessThanZero(double a, double b, double c)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle((a, b, c)));
    }
}
