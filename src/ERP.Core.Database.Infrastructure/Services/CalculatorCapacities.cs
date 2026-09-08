using ERP.Core.Database.Application.Commons.Interfaces.Services;

namespace ERP.Core.Database.Infrastructure.Services;

public class CalculatorCapacities : ICalculatorCapacities
{
    public decimal CalculateAreaM2(decimal width, decimal length)
        => width * length;

    public decimal CalculateAreaM3(decimal areaM2, decimal maximumHeight)
        => areaM2 * maximumHeight;

    public decimal CalculateSpacingTopBetweenWallM2(decimal top, decimal length)
        => top * length;

    public decimal CalculateSpacingBottomBetweenWallM2(decimal bottom, decimal length)
        => bottom * length;

    public decimal CalculateSpacingRightBetweenWallM2(decimal right, decimal width)
        => right * width;

    public decimal CalculateSpacingLeftBetweenWallM2(decimal left, decimal width)
        => left * width;

    public decimal CalculateAvailableSpaceWithSpacingM2(decimal unusedSpaceM2, decimal totalAreaM2)
        => totalAreaM2 - unusedSpaceM2;

    public decimal CalculateUnusedSpaceM2(
        decimal spacingTopBetweenWallM2,
        decimal spacingBottomBetweenWallM2,
        decimal spacingRightBetweenWallM2,
        decimal spacingLeftBetweenWallM2,
        decimal top,
        decimal bottom,
        decimal right,
        decimal left)
    {
        decimal topLeftCorner = top * left;
        decimal topRightCorner = top * right;
        decimal bottomLeftCorner = bottom * left;
        decimal bottomRightCorner = bottom * right;

        decimal totalMarginArea = spacingTopBetweenWallM2 + spacingBottomBetweenWallM2 +
                                  spacingRightBetweenWallM2 + spacingLeftBetweenWallM2 -
                                  (topLeftCorner + topRightCorner + bottomLeftCorner + bottomRightCorner);

        return Math.Max(0, totalMarginArea);
    }

    public decimal CalculateUnusedSpaceM3(decimal unusedSpaceM2, decimal minimumHeight)
        => unusedSpaceM2 * minimumHeight;

    public decimal CalculateAvailableSpaceWithoutSpacingM3(decimal unusedSpaceM3, decimal totalAreaM3)
        => totalAreaM3 - unusedSpaceM3;

    public decimal CalculatePercentageAvailableSpaceWithSpacingM2(decimal availableSpaceWithSpacingM2, decimal totalAreaM2)
        => totalAreaM2 == 0 ? 0 : (availableSpaceWithSpacingM2 / totalAreaM2) * 100;

    public decimal CalculatePercentageAvailableSpaceWithoutSpacingM3(decimal availableSpaceWithoutSpacingM3, decimal totalAreaM3)
        => totalAreaM3 == 0 ? 0 : (availableSpaceWithoutSpacingM3 / totalAreaM3) * 100;
}