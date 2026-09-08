using ERP.Core.Database.Infrastructure.Services;
using Xunit;

namespace ERP.Core.Testing;

public class CalculatorCapacitiesTests
{
    private readonly CalculatorCapacities _sut = new();

    [Fact]
    public void CalculateAreaM2_ShouldReturnWidthTimesLength()
    {
        var result = _sut.CalculateAreaM2(5m, 10m);

        Assert.Equal(50m, result);
    }

    [Fact]
    public void CalculateUnusedSpaceM2_ShouldReturnMarginAreaWithoutCornerOverlap()
    {
        var result = _sut.CalculateUnusedSpaceM2(
            spacingTopBetweenWallM2: 2m,
            spacingBottomBetweenWallM2: 3m,
            spacingRightBetweenWallM2: 4m,
            spacingLeftBetweenWallM2: 5m,
            top: 1m,
            bottom: 2m,
            right: 1m,
            left: 2m);

        Assert.Equal(5m, result);
    }

    [Fact]
    public void CalculatePercentageAvailableSpaceWithSpacingM2_ShouldAvoidDivisionByZero()
    {
        var result = _sut.CalculatePercentageAvailableSpaceWithSpacingM2(10m, 0m);

        Assert.Equal(0m, result);
    }
}
