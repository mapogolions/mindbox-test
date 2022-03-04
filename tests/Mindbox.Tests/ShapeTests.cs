using System;
using Xunit;

namespace Mindbox.Tests;

public class ShapeTest
{
    [Fact]
    public void ShuldReturnZeroIfSidesOfTriangleAreZero()
    {
        var triangle = new Triangle((a: 0, b: 0, c: 0));
        Assert.Equal(0, triangle.Area());
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
