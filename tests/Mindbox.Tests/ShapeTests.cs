using System;
using Xunit;

namespace Mindbox.Tests;

public class ShapeTest
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
    [InlineData(0, 0, 0)]
    [InlineData(1, 2, 3)]
    public void ShouldThrowExceptionWhenSumOfTwoSidesIsLessThanOrEqualToThirdSide(double a,
        double b, double c)
    {
        Assert.Throws<ArgumentException>(() => new Triangle((a, b, c)));
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

    [Theory]
    [InlineData(2, 12.57)]
    [InlineData(3, 28.27)]
    [InlineData(8.3, 216.42)]
    public void ShouldCalculateCircleArea(double radius, double area)
    {
        var circle = new Circle(radius);
        Assert.Equal(area, circle.Area(), precision: 2);
    }

    [Fact]
    public void ShouldThrowExceptionIfRadiusOfCircleIsLessThanZero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-10));
    }

    [Fact]
    public void ShouldReturnPIIfRadiusOfCircleIsOne()
    {
        var circle = new Circle(1);
        Assert.Equal(Math.PI, circle.Area());
    }

    [Fact]
    public void ShouldReturnZeroIfRadiusOfCircleIsZero()
    {
        var circle = new Circle(0);
        Assert.Equal(0, circle.Area());
    }
}
