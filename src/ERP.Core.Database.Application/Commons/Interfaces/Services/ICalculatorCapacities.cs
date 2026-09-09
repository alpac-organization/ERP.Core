namespace ERP.Core.Database.Application.Commons.Interfaces.Services;

public interface ICalculatorCapacities
{
    decimal CalculateAreaM2(decimal width, decimal length);
    decimal CalculateAreaM3(decimal areaM2, decimal height);

    decimal CalculateMarginTopM2(decimal top, decimal length);
    decimal CalculateMarginBottomM2(decimal bottom, decimal length);
    decimal CalculateMarginRightM2(decimal right, decimal width);
    decimal CalculateMarginLeftM2(decimal left, decimal width);

    decimal CalculateAvailableAreaWithMarginM2(decimal unusedAreaM2, decimal totalAreaM2);
    decimal CalculateAvailableVolumenWithMarginM3(decimal unusedVolumenM3, decimal totalVolumenM3);

    decimal CalculateUnusedAreaM2(
        decimal marginTopM2,
        decimal marginBottomM2,
        decimal marginRightM2,
        decimal marginLeftM2,
        decimal top,
        decimal bottom,
        decimal right,
        decimal left);

    decimal CalculateUnusedVolumenM3(decimal unusedAreaM2, decimal height);

    decimal CalculatePercentageAvailableAreaWithMarginM2(decimal availableAreaWithMarginM2, decimal totalAreaM2);
    decimal CalculatePercentageAvailableVolumenWithMarginM3(decimal availableVolumenWithMarginM3, decimal totalVolumenM3);
}