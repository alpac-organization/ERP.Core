namespace ERP.Core.Database.Application.Commons.Interfaces.Services.WarehouseCapacities;

public interface IRackCapacityCalculator
{
    Task<CalculateRackResult> CalculateRackAsync(Guid sectionId, decimal width, decimal length, decimal? height, CancellationToken ct = default);

    Task<CalculateRackResult> UpdateRackAsync(Guid rackId, decimal? width, decimal? length, decimal? height, CancellationToken ct = default);

    Task<CalculateRackResult> DeleteRackAsync(Guid rackId, CancellationToken ct = default);
}