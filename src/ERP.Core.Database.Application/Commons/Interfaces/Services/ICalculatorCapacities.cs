namespace ERP.Core.Database.Application.Commons.Interfaces.Services;

public interface ICalculatorCapacities
{
    decimal CalculateAreaM2(decimal width, decimal length);
    decimal CalculateAreaM3(decimal areaM2, decimal maximumHeight);

    decimal CalculateSpacingTopBetweenWallM2(decimal top, decimal length);
    decimal CalculateSpacingBottomBetweenWallM2(decimal bottom, decimal length);
    decimal CalculateSpacingRightBetweenWallM2(decimal right, decimal width);
    decimal CalculateSpacingLeftBetweenWallM2(decimal left, decimal width);

    decimal CalculateAvailableSpaceWithSpacingM2(decimal unusedSpaceM2, decimal totalAreaM2);
    decimal CalculateAvailableSpaceWithoutSpacingM3(decimal unusedSpaceM3, decimal totalAreaM3);

    decimal CalculateUnusedSpaceM2(
        decimal spacingTopBetweenWallM2,
        decimal spacingBottomBetweenWallM2,
        decimal spacingRightBetweenWallM2,
        decimal spacingLeftBetweenWallM2,
        decimal top,
        decimal bottom,
        decimal right,
        decimal left);

    decimal CalculateUnusedSpaceM3(decimal unusedSpaceM2, decimal minimumHeight);

    decimal CalculatePercentageAvailableSpaceWithSpacingM2(decimal availableSpaceWithSpacingM2, decimal totalAreaM2);
    decimal CalculatePercentageAvailableSpaceWithoutSpacingM3(decimal availableSpaceWithoutSpacingM3, decimal totalAreaM3);
}