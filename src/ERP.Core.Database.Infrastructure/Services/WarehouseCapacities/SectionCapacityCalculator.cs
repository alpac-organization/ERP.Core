using ERP.Core.Database.Application.Commons.Interfaces.Services;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;
using ERP.Core.Database.Application.Commons.Interfaces.Services.WarehouseCapacities;

namespace ERP.Core.Database.Infrastructure.Services.WarehouseCapacities;

public class SectionCapacityCalculator(
    ICalculatorCapacities calculator,
    IUnitOfWork unitOfWork) : CapacityCalculatorBase(calculator, unitOfWork), ISectionCapacityCalculator
{
    public async Task<CalculateSectionResult> CalculateSectionAsync(
        Guid warehouseId,
        decimal width, decimal length,
        CancellationToken ct = default)
    {
        var sectionCapacity = BuildSectionCapacity(
            width, length,
            racks: [],
            lots: []);

        var warehouse = await RecalculateWarehouseAsync(warehouseId, ct: ct);

        return new CalculateSectionResult(sectionCapacity, warehouse);
    }

    public async Task<CalculateSectionResult> UpdateSectionAsync(
        Guid sectionId,
        decimal? width, decimal? length,
        CancellationToken ct = default)
    {
        var section = await LoadSectionWithStoragesAsync(sectionId, ct);
        if (section is null)
            return new CalculateSectionResult(null, null);

        var stored = section.SectionCapacity;

        var sectionCapacity = BuildSectionCapacity(
            width ?? stored?.Witdh ?? 0,
            length ?? stored?.Length ?? 0,
            SelectRackCapacities(section.Racks),
            SelectLotsCapacities(section.Lots));

        var warehouse = await RecalculateWarehouseAsync(
            section.WarehouseId, replaceSectionId: section.Id,
            replaceSectionUsableM2: sectionCapacity.UsableAreaM2, ct: ct);

        return new CalculateSectionResult(sectionCapacity, warehouse);
    }

    public async Task<CalculateSectionResult> DeleteSectionAsync(Guid sectionId, CancellationToken ct = default)
    {
        var section = await LoadSectionWithStoragesAsync(sectionId, ct);
        if (section is null)
            return new CalculateSectionResult(null, null);

        var warehouse = await RecalculateWarehouseAsync(
            section.WarehouseId, excludeSectionId: section.Id, ct: ct);

        return new CalculateSectionResult(null, warehouse);
    }
}