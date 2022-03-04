using System;
using Xunit;

namespace Mindbox.Tests;

public class ShapeTest
{
    [Theory]
    [InlineData(-1, 0, 0)]
    [InlineData(0, -1, 0)]
    [InlineData(0, 0, -1)]
    public void ShouldThrowExceptionIfAtLeastOneSideIsLessThanZero(double a, double b, double c)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle((a, b, c)));
    }

    [Fact]
    public void ShuldReturnZeroIfSidesOfTriangleAreZero()
    {
        var triangle = new Triangle((a: 0, b: 0, c: 0));
        Assert.Equal(0, triangle.Area());
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
