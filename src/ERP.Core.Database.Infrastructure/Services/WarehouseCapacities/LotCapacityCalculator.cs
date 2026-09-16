using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Application.Commons.Interfaces.Services;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;
using ERP.Core.Database.Application.Commons.Interfaces.Services.WarehouseCapacities;

namespace ERP.Core.Database.Infrastructure.Services.WarehouseCapacities;

public class LotCapacityCalculator(
    ICalculatorCapacities calculator,
    IUnitOfWork unitOfWork) : CapacityCalculatorBase(calculator, unitOfWork), ILotCapacityCalculator
{
    public async Task<CalculateLotResult> CalculateLotAsync(
        Guid sectionId,
        decimal width, decimal length,
        CancellationToken ct = default)
    {
        var result = await CalculateLotsAsync(sectionId, [(width, length)], ct);

        return new CalculateLotResult(result.Lots.Single(), result.Section, result.Warehouse);
    }

    public async Task<CalculateLotsResult> CalculateLotsAsync(
        Guid sectionId,
        IReadOnlyCollection<(decimal Width, decimal Length)> lots,
        CancellationToken ct = default)
    {
        var lotCapacities = lots.Select(l => BuildLotsCapacity(l.Width, l.Length)).ToArray();

        var section = await LoadSectionWithStoragesAsync(sectionId, ct);
        if (section?.SectionCapacity is null)
            return new CalculateLotsResult(lotCapacities, null, null);

        var sectionCapacity = BuildSectionCapacity(
            section.SectionCapacity.Width, section.SectionCapacity.Length,
            section.SectionType,
            section.SectionStorageType,
            SelectRackCapacities(section.Racks),
            SelectLotsCapacities(section.Lots).Concat(lotCapacities));

        var warehouse = await RecalculateWarehouseAsync(
            section.WarehouseId, newSectionCapacity: sectionCapacity, replaceSectionId: section.Id, ct: ct);

        return new CalculateLotsResult(lotCapacities, sectionCapacity, warehouse);
    }

    public async Task<CalculateLotResult> UpdateLotAsync(
        Guid lotId,
        decimal? width, decimal? length,
        CancellationToken ct = default)
    {
        var lot = await UnitOfWork.Lots.Entities
            .AsNoTracking()
            .Include(l => l.LotsCapacity)
            .FirstOrDefaultAsync(l => l.Id == lotId && l.DeletedAt == null, ct);
        if (lot is null)
            return new CalculateLotResult(null, null, null);

        var stored = lot.LotsCapacity;

        var lotCapacity = BuildLotsCapacity(
            width ?? stored?.Width ?? 0,
            length ?? stored?.Length ?? 0);

        var section = await LoadSectionWithStoragesAsync(lot.SectionId, ct);
        if (section?.SectionCapacity is null)
            return new CalculateLotResult(lotCapacity, null, null);

        var lots = SelectLotsCapacities(section.Lots)
            .Where(c => c.LotsId != lotId)
            .Append(lotCapacity);

        var sectionCapacity = BuildSectionCapacity(
            section.SectionCapacity.Width, section.SectionCapacity.Length,
            section.SectionType,
            section.SectionStorageType,
            SelectRackCapacities(section.Racks),
            lots);

        var warehouse = await RecalculateWarehouseAsync(
            section.WarehouseId, newSectionCapacity: sectionCapacity, replaceSectionId: section.Id, ct: ct);

        return new CalculateLotResult(lotCapacity, sectionCapacity, warehouse);
    }

    public async Task<CalculateLotResult> DeleteLotAsync(Guid lotId, CancellationToken ct = default)
    {
        var lot = await UnitOfWork.Lots.Entities
            .AsNoTracking()
            .FirstOrDefaultAsync(l => l.Id == lotId && l.DeletedAt == null, ct);
        if (lot is null)
            return new CalculateLotResult(null, null, null);

        var section = await LoadSectionWithStoragesAsync(lot.SectionId, ct);
        if (section?.SectionCapacity is null)
            return new CalculateLotResult(null, null, null);

        var lots = SelectLotsCapacities(section.Lots)
            .Where(c => c.LotsId != lotId);

        var sectionCapacity = BuildSectionCapacity(
            section.SectionCapacity.Width, section.SectionCapacity.Length,
            section.SectionType,
            section.SectionStorageType,
            SelectRackCapacities(section.Racks),
            lots);

        var warehouse = await RecalculateWarehouseAsync(
            section.WarehouseId, newSectionCapacity: sectionCapacity, replaceSectionId: section.Id, ct: ct);

        return new CalculateLotResult(null, sectionCapacity, warehouse);
    }
}