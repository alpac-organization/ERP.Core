namespace ERP.Core.Database.Application.Commons.Interfaces.Services.WarehouseCapacities;

public interface ILotCapacityCalculator
{
    Task<CalculateLotResult> CalculateLotAsync(Guid sectionId, decimal width, decimal length, CancellationToken ct = default);

    Task<CalculateLotResult> UpdateLotAsync(Guid lotId, decimal? width, decimal? length, CancellationToken ct = default);

    Task<CalculateLotResult> DeleteLotAsync(Guid lotId, CancellationToken ct = default);
}