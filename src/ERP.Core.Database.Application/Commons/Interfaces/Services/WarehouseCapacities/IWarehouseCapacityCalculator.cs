namespace ERP.Core.Database.Application.Commons.Interfaces.Services.WarehouseCapacities;

public interface IWarehouseCapacityCalculator
{
    Task<CalculateWarehouseResult> CalculateWarehouseAsync(decimal width, decimal length,
        bool hasMargins,
        decimal? minimumHeight, decimal? maximumHeight,
        decimal? marginTop, decimal? marginBottom,
        decimal? marginRight, decimal? marginLeft,
        CancellationToken ct = default);

    Task<CalculateWarehouseResult> UpdateWarehouseAsync(Guid warehouseId, decimal? width, decimal? length,
        bool? hasMargins,
        decimal? minimumHeight, decimal? maximumHeight,
        decimal? marginTop, decimal? marginBottom,
        decimal? marginRight, decimal? marginLeft,
        CancellationToken ct = default);

    Task DeleteWarehouseAsync(Guid warehouseId, CancellationToken ct = default);
}