namespace ERP.Core.Database.Application.Commons.Interfaces.Services;

public interface IWarehouseCapacityCalculator
{
    Task<CalculateRackResult> CalculateRackAsync(Guid sectionId, decimal width, decimal length, decimal? height, CancellationToken ct = default);

    Task<CalculateLotResult> CalculateLotAsync(Guid sectionId, decimal width, decimal length, CancellationToken ct = default);

    Task<CalculateSectionResult> CalculateSectionAsync(Guid warehouseId, decimal width, decimal length, CancellationToken ct = default);

    Task<CalculateWarehouseResult> CalculateWarehouseAsync(decimal width, decimal length,
        bool hasSpaceBetweenWall,
        decimal? minimumHeight, decimal? maximumHeight,
        decimal? spacingTop, decimal? spacingBottom,
        decimal? spacingRight, decimal? spacingLeft,
        CancellationToken ct = default);
}