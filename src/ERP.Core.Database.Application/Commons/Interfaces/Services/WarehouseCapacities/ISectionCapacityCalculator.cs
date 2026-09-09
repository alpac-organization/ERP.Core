namespace ERP.Core.Database.Application.Commons.Interfaces.Services.WarehouseCapacities;

public interface ISectionCapacityCalculator
{
    Task<CalculateSectionResult> CalculateSectionAsync(Guid warehouseId, decimal width, decimal length, CancellationToken ct = default);

    Task<CalculateSectionResult> UpdateSectionAsync(Guid sectionId, decimal? width, decimal? length, CancellationToken ct = default);

    Task<CalculateSectionResult> DeleteSectionAsync(Guid sectionId, CancellationToken ct = default);
}