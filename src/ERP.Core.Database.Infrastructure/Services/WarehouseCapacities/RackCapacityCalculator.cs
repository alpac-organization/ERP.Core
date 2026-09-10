using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Application.Commons.Interfaces.Services;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;
using ERP.Core.Database.Application.Commons.Interfaces.Services.WarehouseCapacities;

namespace ERP.Core.Database.Infrastructure.Services.WarehouseCapacities;

public class RackCapacityCalculator(
    ICalculatorCapacities calculator,
    IUnitOfWork unitOfWork) : CapacityCalculatorBase(calculator, unitOfWork), IRackCapacityCalculator
{
    public async Task<CalculateRackResult> CalculateRackAsync(
        Guid sectionId,
        decimal width, decimal length, decimal? height,
        CancellationToken ct = default)
    {
        var rackCapacity = BuildRackCapacity(width, length, height);

        var section = await LoadSectionWithStoragesAsync(sectionId, ct);
        if (section?.SectionCapacity is null)
            return new CalculateRackResult(rackCapacity, null, null);

        var sectionCapacity = BuildSectionCapacity(
            section.SectionCapacity.Width, section.SectionCapacity.Length,
            section.SectionType,
            section.SectionStorageType,
            SelectRackCapacities(section.Racks).Append(rackCapacity),
            SelectLotsCapacities(section.Lots));

        var warehouse = await RecalculateWarehouseAsync(
            section.WarehouseId, newSectionCapacity: sectionCapacity, replaceSectionId: section.Id, ct: ct);

        return new CalculateRackResult(rackCapacity, sectionCapacity, warehouse);
    }

    public async Task<CalculateRackResult> UpdateRackAsync(
        Guid rackId,
        decimal? width, decimal? length, decimal? height,
        CancellationToken ct = default)
    {
        var rack = await UnitOfWork.Racks.Entities
            .AsNoTracking()
            .Include(r => r.RackCapacity)
            .FirstOrDefaultAsync(r => r.Id == rackId && r.DeletedAt == null, ct);
        if (rack is null)
            return new CalculateRackResult(null, null, null);

        var stored = rack.RackCapacity;

        var rackCapacity = BuildRackCapacity(
            width ?? stored?.Width ?? 0,
            length ?? stored?.Length ?? 0,
            height ?? stored?.Height);

        var section = await LoadSectionWithStoragesAsync(rack.SectionId, ct);
        if (section?.SectionCapacity is null)
            return new CalculateRackResult(rackCapacity, null, null);

        var racks = SelectRackCapacities(section.Racks)
            .Where(c => c.RackId != rackId)
            .Append(rackCapacity);

        var sectionCapacity = BuildSectionCapacity(
            section.SectionCapacity.Width, section.SectionCapacity.Length,
            section.SectionType,
            section.SectionStorageType,
            racks,
            SelectLotsCapacities(section.Lots));

        var warehouse = await RecalculateWarehouseAsync(
            section.WarehouseId, newSectionCapacity: sectionCapacity, replaceSectionId: section.Id, ct: ct);

        return new CalculateRackResult(rackCapacity, sectionCapacity, warehouse);
    }

    public async Task<CalculateRackResult> DeleteRackAsync(Guid rackId, CancellationToken ct = default)
    {
        var rack = await UnitOfWork.Racks.Entities
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == rackId && r.DeletedAt == null, ct);
        if (rack is null)
            return new CalculateRackResult(null, null, null);

        var section = await LoadSectionWithStoragesAsync(rack.SectionId, ct);
        if (section?.SectionCapacity is null)
            return new CalculateRackResult(null, null, null);

        var racks = SelectRackCapacities(section.Racks)
            .Where(c => c.RackId != rackId);

        var sectionCapacity = BuildSectionCapacity(
            section.SectionCapacity.Width, section.SectionCapacity.Length,
            section.SectionType,
            section.SectionStorageType,
            racks,
            SelectLotsCapacities(section.Lots));

        var warehouse = await RecalculateWarehouseAsync(
            section.WarehouseId, newSectionCapacity: sectionCapacity, replaceSectionId: section.Id, ct: ct);

        return new CalculateRackResult(null, sectionCapacity, warehouse);
    }
}