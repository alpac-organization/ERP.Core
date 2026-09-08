using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Application.Commons.Interfaces.Services;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;

namespace ERP.Core.Database.Infrastructure.Services;

public class WarehouseCapacityCalculator(
    ICalculatorCapacities calculator,
    IUnitOfWork unitOfWork) : IWarehouseCapacityCalculator
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
            section.SectionCapacity.Witdh, section.SectionCapacity.Length,
            SelectRackCapacities(section.Racks).Append(rackCapacity),
            SelectLotsCapacities(section.Lots));

        var warehouse = await RecalculateWarehouseAsync(
            section.WarehouseId, section.Id, sectionCapacity.UsableAreaM2, ct);

        return new CalculateRackResult(rackCapacity, sectionCapacity, warehouse);
    }

    public async Task<CalculateLotResult> CalculateLotAsync(
        Guid sectionId,
        decimal width, decimal length,
        CancellationToken ct = default)
    {
        var lotCapacity = BuildLotsCapacity(width, length);

        var section = await LoadSectionWithStoragesAsync(sectionId, ct);
        if (section?.SectionCapacity is null)
            return new CalculateLotResult(lotCapacity, null, null);

        var sectionCapacity = BuildSectionCapacity(
            section.SectionCapacity.Witdh, section.SectionCapacity.Length,
            SelectRackCapacities(section.Racks),
            SelectLotsCapacities(section.Lots).Append(lotCapacity));

        var warehouse = await RecalculateWarehouseAsync(
            section.WarehouseId, section.Id, sectionCapacity.UsableAreaM2, ct);

        return new CalculateLotResult(lotCapacity, sectionCapacity, warehouse);
    }

    public async Task<CalculateSectionResult> CalculateSectionAsync(
        Guid warehouseId,
        decimal width, decimal length,
        CancellationToken ct = default)
    {
        var sectionCapacity = BuildSectionCapacity(
            width, length,
            racks: [],
            lots: []);

        var warehouse = await RecalculateWarehouseAsync(warehouseId, null, null, ct);

        return new CalculateSectionResult(sectionCapacity, warehouse);
    }

    public Task<CalculateWarehouseResult> CalculateWarehouseAsync(
        decimal width, decimal length,
        bool hasSpaceBetweenWall,
        decimal? minimumHeight, decimal? maximumHeight,
        decimal? spacingTop, decimal? spacingBottom,
        decimal? spacingRight, decimal? spacingLeft,
        CancellationToken ct = default)
    {
        var capacity = BuildWarehouseCapacity(width, length, hasSpaceBetweenWall,
            minimumHeight, maximumHeight,
            spacingTop, spacingBottom, spacingRight, spacingLeft);
        capacity.UnusedSpaceM2 = capacity.AvailableSpaceWithSpacingM2;

        return Task.FromResult(new CalculateWarehouseResult(capacity));
    }

    private async Task<Sections?> LoadSectionWithStoragesAsync(Guid sectionId, CancellationToken ct)
        => await unitOfWork.Sections.Entities
            .AsNoTracking()
            .Include(s => s.SectionCapacity)
            .Include(s => s.Racks).ThenInclude(r => r.RackCapacity)
            .Include(s => s.Lots).ThenInclude(l => l.LotsCapacity)
            .FirstOrDefaultAsync(s => s.Id == sectionId, ct);

    private async Task<WarehouseCapacity?> RecalculateWarehouseAsync(
        Guid warehouseId,
        Guid? replaceSectionId,
        decimal? replaceSectionUsableM2,
        CancellationToken ct)
    {
        var warehouse = await unitOfWork.Warehouses.Entities
            .AsNoTracking()
            .Include(w => w.WarehouseCapacity)
            .Include(w => w.Sections).ThenInclude(s => s.SectionCapacity)
            .FirstOrDefaultAsync(w => w.Id == warehouseId, ct);
        if (warehouse?.WarehouseCapacity is null)
            return null;

        var saved = warehouse.WarehouseCapacity;
        var capacity = BuildWarehouseCapacity(saved.Witdh, saved.Length, saved.HasSpaceBetweenWall,
            saved.MinimumHeight, saved.MaximumHeight,
            saved.SpacingTop, saved.SpacingBotton, saved.SpacingRight, saved.SpacingLeft);

        var usedM2 = warehouse.Sections.Sum(section =>
            section.Id == replaceSectionId
                ? (replaceSectionUsableM2 ?? 0)
                : (section.SectionCapacity?.UsableAreaM2 ?? 0));

        capacity.UnusedSpaceM2 = Math.Max(0, capacity.AvailableSpaceWithSpacingM2 - usedM2);

        return capacity;
    }

    private static IEnumerable<RackCapacity> SelectRackCapacities(IEnumerable<Racks> racks)
    {
        foreach (var rack in racks)
        {
            if (rack.RackCapacity is not null)
                yield return rack.RackCapacity;
        }
    }

    private static IEnumerable<LotsCapacity> SelectLotsCapacities(IEnumerable<Lots> lots)
    {
        foreach (var lot in lots)
        {
            if (lot.LotsCapacity is not null)
                yield return lot.LotsCapacity;
        }
    }

    private RackCapacity BuildRackCapacity(decimal width, decimal length, decimal? height)
    {
        var totalM2 = calculator.CalculateAreaM2(width, length);

        return new RackCapacity
        {
            Witdh = width,
            Length = length,
            Height = height,
            UnusedSpaceM2 = 0,
            AvailableSpaceWithSpacingM2 = totalM2,
            AvailableSpaceWithoutSpacingM2 = totalM2,
            PercenteAvailableSpaceWithSpacingM2 = totalM2 == 0 ? 0 : 100,
            PercenteAvailableSpaceWithSpacingM3 = 0
        };
    }

    private LotsCapacity BuildLotsCapacity(decimal width, decimal length)
    {
        var totalM2 = calculator.CalculateAreaM2(width, length);

        return new LotsCapacity
        {
            Witdh = width,
            Length = length,
            UnusedSpaceM2 = 0,
            AvailableSpaceWithSpacingM2 = totalM2,
            AvailableSpaceWithoutSpacingM2 = totalM2,
            PercenteAvailableSpaceWithSpacingM2 = totalM2 == 0 ? 0 : 100,
            PercenteAvailableSpaceWithSpacingM3 = 0
        };
    }

    private SectionCapacity BuildSectionCapacity(
        decimal width, decimal length,
        IEnumerable<RackCapacity> racks, IEnumerable<LotsCapacity> lots)
    {
        var areaSection = calculator.CalculateAreaM2(width, length);
        var sumAvailableM2 = (racks ?? []).Sum(r => r.AvailableSpaceWithoutSpacingM2)
                           + (lots ?? []).Sum(l => l.AvailableSpaceWithoutSpacingM2);
        var unusedSpaceM2 = Math.Max(0, areaSection - sumAvailableM2);

        return new SectionCapacity
        {
            Witdh = width,
            Length = length,
            UsableAreaM2 = sumAvailableM2,
            UnusableAreaM2 = unusedSpaceM2,
            UnusedSpaceM2 = unusedSpaceM2,
            AvailableSpaceWithSpacingM2 = sumAvailableM2,
            AvailableSpaceWithoutSpacingM2 = areaSection,
            PercenteAvailableSpaceWithSpacingM2 =
                calculator.CalculatePercentageAvailableSpaceWithSpacingM2(sumAvailableM2, areaSection),
            PercenteAvailableSpaceWithSpacingM3 = 0
        };
    }

    private WarehouseCapacity BuildWarehouseCapacity(
        decimal width, decimal length,
        bool hasSpaceBetweenWall,
        decimal? minimumHeight, decimal? maximumHeight,
        decimal? spacingTop, decimal? spacingBottom,
        decimal? spacingRight, decimal? spacingLeft)
    {
        var totalM2 = calculator.CalculateAreaM2(width, length);

        var spacingTopM2 = spacingTop is null
            ? 0
            : calculator.CalculateSpacingTopBetweenWallM2(spacingTop.Value, length);
        var spacingBottomM2 = spacingBottom is null
            ? 0
            : calculator.CalculateSpacingBottomBetweenWallM2(spacingBottom.Value, length);
        var spacingRightM2 = spacingRight is null
            ? 0
            : calculator.CalculateSpacingRightBetweenWallM2(spacingRight.Value, width);
        var spacingLeftM2 = spacingLeft is null
            ? 0
            : calculator.CalculateSpacingLeftBetweenWallM2(spacingLeft.Value, width);

        var anySpacing = spacingTop is not null
                         || spacingBottom is not null
                         || spacingRight is not null
                         || spacingLeft is not null;

        var unusedSpaceM2 = hasSpaceBetweenWall && anySpacing
            ? calculator.CalculateUnusedSpaceM2(
                spacingTopM2,
                spacingBottomM2,
                spacingRightM2,
                spacingLeftM2,
                spacingTop ?? 0,
                spacingBottom ?? 0,
                spacingRight ?? 0,
                spacingLeft ?? 0)
            : 0;

        var availableWithSpacingM2 = calculator.CalculateAvailableSpaceWithSpacingM2(unusedSpaceM2, totalM2);

        var maximumHeightValue = maximumHeight ?? minimumHeight;
        var minimumHeightValue = minimumHeight ?? maximumHeight;

        var totalM3 = maximumHeightValue is null
            ? 0
            : calculator.CalculateAreaM3(totalM2, maximumHeightValue.Value);

        var unusedSpaceM3 = minimumHeightValue is null
            ? 0
            : calculator.CalculateUnusedSpaceM3(unusedSpaceM2, minimumHeightValue.Value);

        var availableWithoutSpacingM3 = calculator.CalculateAvailableSpaceWithoutSpacingM3(unusedSpaceM3, totalM3);

        return new WarehouseCapacity
        {
            Witdh = width,
            Length = length,
            MinimumHeight = minimumHeight,
            MaximumHeight = maximumHeight,
            HasSpaceBetweenWall = hasSpaceBetweenWall,
            SpacingTop = spacingTop,
            SpacingBotton = spacingBottom,
            SpacingRight = spacingRight,
            SpacingLeft = spacingLeft,
            UnusedSpaceM2 = unusedSpaceM2,
            AvailableSpaceWithSpacingM2 = availableWithSpacingM2,
            AvailableSpaceWithoutSpacingM2 = totalM2,
            PercenteAvailableSpaceWithSpacingM2 =
                calculator.CalculatePercentageAvailableSpaceWithSpacingM2(availableWithSpacingM2, totalM2),
            UnasedSpaceM3 = unusedSpaceM3,
            AvailableSpaceWithSpacingM3 = availableWithoutSpacingM3,
            AvailableSpaceWithoutSpacingM3 = totalM3,
            PercenteAvailableSpaceWithSpacingM3 =
                calculator.CalculatePercentageAvailableSpaceWithoutSpacingM3(availableWithoutSpacingM3, totalM3)
        };
    }
}