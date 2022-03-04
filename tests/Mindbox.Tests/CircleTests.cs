using System;
using Xunit;

namespace Mindbox.Tests;

public class CircleTest
{
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
    public void ShouldReturnPIIfRadiusOfCircleIsEqualToOne()
    {
        var circle = new Circle(1);
        Assert.Equal(Math.PI, circle.Area());
    }

    [Fact]
    public void ShouldReturnZeroIfRadiusOfCircleIsEqualToZero()
    {
        var circle = new Circle(0);
        Assert.Equal(0, circle.Area());
    }
}
