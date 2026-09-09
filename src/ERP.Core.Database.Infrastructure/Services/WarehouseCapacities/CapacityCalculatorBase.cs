using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Application.Commons.Interfaces.Services;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;

namespace ERP.Core.Database.Infrastructure.Services.WarehouseCapacities;

public abstract class CapacityCalculatorBase(
    ICalculatorCapacities calculator,
    IUnitOfWork unitOfWork)
{
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;

    protected async Task<Sections?> LoadSectionWithStoragesAsync(Guid sectionId, CancellationToken ct)
        => await UnitOfWork.Sections.Entities
            .AsNoTracking()
            .Include(s => s.SectionCapacity)
            .Include(s => s.Racks.Where(r => r.DeletedAt == null)).ThenInclude(r => r.RackCapacity)
            .Include(s => s.Lots.Where(l => l.DeletedAt == null)).ThenInclude(l => l.LotsCapacity)
            .FirstOrDefaultAsync(s => s.Id == sectionId, ct);

    protected async Task<WarehouseCapacity?> RecalculateWarehouseAsync(
        Guid warehouseId,
        SectionCapacity? newSectionCapacity = null,
        Guid? replaceSectionId = null,
        Guid? excludeSectionId = null,
        CancellationToken ct = default)
    {
        var warehouse = await UnitOfWork.Warehouses.Entities
            .AsNoTracking()
            .Include(w => w.WarehouseCapacity)
            .Include(w => w.Sections.Where(s => s.DeletedAt == null)).ThenInclude(s => s.SectionCapacity)
            .FirstOrDefaultAsync(w => w.Id == warehouseId, ct);
        if (warehouse?.WarehouseCapacity is null)
            return null;

        var saved = warehouse.WarehouseCapacity;
        var capacity = BuildWarehouseCapacity(
            saved.Width, saved.Length, saved.HasMargins,
            saved.MinimumHeight, saved.MaximumHeight,
            saved.MarginTop, saved.MarginBottom, saved.MarginRight, saved.MarginLeft,
            BuildEffectiveSections(warehouse.Sections, newSectionCapacity, replaceSectionId, excludeSectionId));

        return capacity;
    }

    private static IEnumerable<SectionCapacity?> BuildEffectiveSections(
        IEnumerable<Sections> sections,
        SectionCapacity? newSectionCapacity,
        Guid? replaceSectionId,
        Guid? excludeSectionId)
    {
        var replaced = false;

        foreach (var section in sections)
        {
            if (section.Id == excludeSectionId)
                continue;

            if (section.Id == replaceSectionId)
            {
                yield return newSectionCapacity;
                replaced = true;
                continue;
            }

            yield return section.SectionCapacity;
        }

        if (!replaced && replaceSectionId is null && newSectionCapacity is not null)
            yield return newSectionCapacity;
    }

    protected static IEnumerable<RackCapacity> SelectRackCapacities(IEnumerable<Racks> racks)
    {
        foreach (var rack in racks)
        {
            if (rack.RackCapacity is not null)
                yield return rack.RackCapacity;
        }
    }

    protected static IEnumerable<LotsCapacity> SelectLotsCapacities(IEnumerable<Lots> lots)
    {
        foreach (var lot in lots)
        {
            if (lot.LotsCapacity is not null)
                yield return lot.LotsCapacity;
        }
    }

    protected RackCapacity BuildRackCapacity(decimal width, decimal length, decimal? height)
    {
        var totalM2 = calculator.CalculateAreaM2(width, length);

        return new RackCapacity
        {
            Width = width,
            Length = length,
            Height = height,
            UnusedAreaM2 = 0,
            AvailableAreaWithMarginM2 = totalM2,
            TotalAreaM2 = totalM2,
            UnoccupiedChargeableAreaM2 = totalM2,
            OccupiedChargeableAreaM2 = 0,
            PercentageAvailableAreaWithMarginM2 = totalM2 == 0 ? 0 : 100
        };
    }

    protected LotsCapacity BuildLotsCapacity(decimal width, decimal length)
    {
        var totalM2 = calculator.CalculateAreaM2(width, length);

        return new LotsCapacity
        {
            Width = width,
            Length = length,
            UnusedAreaM2 = 0,
            AvailableAreaWithMarginM2 = totalM2,
            TotalAreaM2 = totalM2,
            UnoccupiedChargeableAreaM2 = totalM2,
            OccupiedChargeableAreaM2 = 0,
            PercentageAvailableAreaWithMarginM2 = totalM2 == 0 ? 0 : 100
        };
    }

    protected SectionCapacity BuildSectionCapacity(
        decimal width, decimal length,
        SectionType sectionType,
        IEnumerable<RackCapacity> racks, IEnumerable<LotsCapacity> lots)
    {
        var totalM2 = calculator.CalculateAreaM2(width, length);
        var isAisle = sectionType == SectionType.Aisle;

        var unoccupiedChargeableM2 = isAisle
            ? 0
            : (racks ?? []).Sum(r => r.UnoccupiedChargeableAreaM2)
            + (lots ?? []).Sum(l => l.UnoccupiedChargeableAreaM2);

        var occupiedChargeableM2 = isAisle
            ? 0
            : (racks ?? []).Sum(r => r.OccupiedChargeableAreaM2)
            + (lots ?? []).Sum(l => l.OccupiedChargeableAreaM2);

        var unusedM2 = isAisle ? totalM2 : 0;
        var availableM2 = totalM2 - unusedM2;

        return new SectionCapacity
        {
            Width = width,
            Length = length,
            UnusedAreaM2 = unusedM2,
            AvailableAreaWithMarginM2 = availableM2,
            TotalAreaM2 = totalM2,
            UnoccupiedChargeableAreaM2 = unoccupiedChargeableM2,
            OccupiedChargeableAreaM2 = occupiedChargeableM2,
            PercentageAvailableAreaWithMarginM2 =
                calculator.CalculatePercentageAvailableAreaWithMarginM2(availableM2, totalM2)
        };
    }

    protected WarehouseCapacity BuildWarehouseCapacity(
        decimal width, decimal length,
        bool hasMargins,
        decimal? minimumHeight, decimal? maximumHeight,
        decimal? marginTop, decimal? marginBottom,
        decimal? marginRight, decimal? marginLeft,
        IEnumerable<SectionCapacity?> sections)
    {
        var totalM2 = calculator.CalculateAreaM2(width, length);

        var marginTopM2 = marginTop is null
            ? 0
            : calculator.CalculateMarginTopM2(marginTop.Value, length);
        var marginBottomM2 = marginBottom is null
            ? 0
            : calculator.CalculateMarginBottomM2(marginBottom.Value, length);
        var marginRightM2 = marginRight is null
            ? 0
            : calculator.CalculateMarginRightM2(marginRight.Value, width);
        var marginLeftM2 = marginLeft is null
            ? 0
            : calculator.CalculateMarginLeftM2(marginLeft.Value, width);

        var anyMargin = marginTop is not null
                        || marginBottom is not null
                        || marginRight is not null
                        || marginLeft is not null;

        var marginM2 = hasMargins && anyMargin
            ? calculator.CalculateUnusedAreaM2(
                marginTopM2,
                marginBottomM2,
                marginRightM2,
                marginLeftM2,
                marginTop ?? 0,
                marginBottom ?? 0,
                marginRight ?? 0,
                marginLeft ?? 0)
            : 0;

        var sectionsList = (sections ?? []).ToList();

        var unusedM2 = marginM2 + sectionsList.Sum(s => s?.UnusedAreaM2 ?? 0);
        var availableM2 = Math.Max(0, calculator.CalculateAvailableAreaWithMarginM2(unusedM2, totalM2));

        var unoccupiedChargeableM2 = sectionsList.Sum(s => s?.UnoccupiedChargeableAreaM2 ?? 0);
        var occupiedChargeableM2 = sectionsList.Sum(s => s?.OccupiedChargeableAreaM2 ?? 0);

        var unusedVolumeHeight = minimumHeight ?? maximumHeight ?? 0;
        var totalVolumeHeight = maximumHeight ?? minimumHeight ?? 0;
        var chargeableVolumeHeight = maximumHeight ?? minimumHeight ?? 0;

        var unusedVolumenM3 = unusedVolumeHeight == 0
            ? 0
            : calculator.CalculateUnusedVolumenM3(marginM2, unusedVolumeHeight);

        var totalVolumenM3 = totalVolumeHeight == 0
            ? 0
            : calculator.CalculateAreaM3(totalM2, totalVolumeHeight);

        var availableVolumenM3 = Math.Max(0,
            calculator.CalculateAvailableVolumenWithMarginM3(unusedVolumenM3, totalVolumenM3));

        var unoccupiedChargeableVolumenM3 = unoccupiedChargeableM2 * chargeableVolumeHeight;
        var occupiedChargeableVolumenM3 = occupiedChargeableM2 * chargeableVolumeHeight;

        return new WarehouseCapacity
        {
            Width = width,
            Length = length,
            HasMargins = hasMargins,
            MinimumHeight = minimumHeight,
            MaximumHeight = maximumHeight,
            MarginTop = marginTop,
            MarginBottom = marginBottom,
            MarginRight = marginRight,
            MarginLeft = marginLeft,
            UnusedAreaM2 = unusedM2,
            AvailableAreaWithMarginM2 = availableM2,
            TotalAreaM2 = totalM2,
            UnoccupiedChargeableAreaM2 = unoccupiedChargeableM2,
            OccupiedChargeableAreaM2 = occupiedChargeableM2,
            PercentageAvailableAreaWithMarginM2 =
                calculator.CalculatePercentageAvailableAreaWithMarginM2(availableM2, totalM2),
            UnusedVolumenM3 = unusedVolumenM3,
            AvailableVolumenWithMarginM3 = availableVolumenM3,
            TotalVolumenM3 = totalVolumenM3,
            UnoccupiedChargeableVolumenM3 = unoccupiedChargeableVolumenM3,
            OccupiedChargeableVolumenM3 = occupiedChargeableVolumenM3,
            PercentageAvailableVolumenWithMarginM3 =
                calculator.CalculatePercentageAvailableVolumenWithMarginM3(availableVolumenM3, totalVolumenM3)
        };
    }
}