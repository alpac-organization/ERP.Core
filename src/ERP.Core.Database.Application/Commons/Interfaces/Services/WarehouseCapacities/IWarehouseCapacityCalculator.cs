namespace ERP.Core.Database.Application.Commons.Interfaces.Services.WarehouseCapacities;

public interface IWarehouseCapacityCalculator
{
    Task<CalculateWarehouseResult> CalculateWarehouseAsync(decimal width, decimal length,
        bool hasSpaceBetweenWall,
        decimal? minimumHeight, decimal? maximumHeight,
        decimal? spacingTop, decimal? spacingBottom,
        decimal? spacingRight, decimal? spacingLeft,
        CancellationToken ct = default);

    Task<CalculateWarehouseResult> UpdateWarehouseAsync(Guid warehouseId, decimal? width, decimal? length,
        bool? hasSpaceBetweenWall,
        decimal? minimumHeight, decimal? maximumHeight,
        decimal? spacingTop, decimal? spacingBottom,
        decimal? spacingRight, decimal? spacingLeft,
        CancellationToken ct = default);

    Task DeleteWarehouseAsync(Guid warehouseId, CancellationToken ct = default);
}