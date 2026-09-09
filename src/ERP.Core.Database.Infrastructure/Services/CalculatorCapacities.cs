using ERP.Core.Database.Application.Commons.Interfaces.Services;

namespace ERP.Core.Database.Infrastructure.Services;

public class CalculatorCapacities : ICalculatorCapacities
{
    public decimal CalculateAreaM2(decimal width, decimal length)
        => width * length;

    public decimal CalculateAreaM3(decimal areaM2, decimal height)
        => areaM2 * height;

    public decimal CalculateMarginTopM2(decimal top, decimal length)
        => top * length;

    public decimal CalculateMarginBottomM2(decimal bottom, decimal length)
        => bottom * length;

    public decimal CalculateMarginRightM2(decimal right, decimal width)
        => right * width;

    public decimal CalculateMarginLeftM2(decimal left, decimal width)
        => left * width;

    public decimal CalculateAvailableAreaWithMarginM2(decimal unusedAreaM2, decimal totalAreaM2)
        => totalAreaM2 - unusedAreaM2;

    public decimal CalculateAvailableVolumenWithMarginM3(decimal unusedVolumenM3, decimal totalVolumenM3)
        => totalVolumenM3 - unusedVolumenM3;

    public decimal CalculateUnusedAreaM2(
        decimal marginTopM2,
        decimal marginBottomM2,
        decimal marginRightM2,
        decimal marginLeftM2,
        decimal top,
        decimal bottom,
        decimal right,
        decimal left)
    {
        decimal topLeftCorner = top * left;
        decimal topRightCorner = top * right;
        decimal bottomLeftCorner = bottom * left;
        decimal bottomRightCorner = bottom * right;

        decimal totalMarginArea = marginTopM2 + marginBottomM2 +
                                  marginRightM2 + marginLeftM2 -
                                  (topLeftCorner + topRightCorner + bottomLeftCorner + bottomRightCorner);

        return Math.Max(0, totalMarginArea);
    }

    public decimal CalculateUnusedVolumenM3(decimal unusedAreaM2, decimal height)
        => unusedAreaM2 * height;

    public decimal CalculatePercentageAvailableAreaWithMarginM2(decimal availableAreaWithMarginM2, decimal totalAreaM2)
        => totalAreaM2 == 0 ? 0 : (availableAreaWithMarginM2 / totalAreaM2) * 100;

    public decimal CalculatePercentageAvailableVolumenWithMarginM3(decimal availableVolumenWithMarginM3, decimal totalVolumenM3)
        => totalVolumenM3 == 0 ? 0 : (availableVolumenWithMarginM3 / totalVolumenM3) * 100;
}