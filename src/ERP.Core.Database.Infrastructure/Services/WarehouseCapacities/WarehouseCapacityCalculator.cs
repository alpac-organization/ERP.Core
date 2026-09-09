using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Application.Commons.Interfaces.Services;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;
using ERP.Core.Database.Application.Commons.Interfaces.Services.WarehouseCapacities;

namespace ERP.Core.Database.Infrastructure.Services.WarehouseCapacities;

public class WarehouseCapacityCalculator(
    ICalculatorCapacities calculator,
    IUnitOfWork unitOfWork) : CapacityCalculatorBase(calculator, unitOfWork), IWarehouseCapacityCalculator
{
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

    public async Task<CalculateWarehouseResult> UpdateWarehouseAsync(
        Guid warehouseId,
        decimal? width, decimal? length,
        bool? hasSpaceBetweenWall,
        decimal? minimumHeight, decimal? maximumHeight,
        decimal? spacingTop, decimal? spacingBottom,
        decimal? spacingRight, decimal? spacingLeft,
        CancellationToken ct = default)
    {
        var warehouse = await UnitOfWork.Warehouses.Entities
            .AsNoTracking()
            .Include(w => w.WarehouseCapacity)
            .Include(w => w.Sections).ThenInclude(s => s.SectionCapacity)
            .FirstOrDefaultAsync(w => w.Id == warehouseId, ct);
        if (warehouse is null)
            return new CalculateWarehouseResult(null);

        var stored = warehouse.WarehouseCapacity;

        var capacity = BuildWarehouseCapacity(
            width ?? stored?.Witdh ?? 0,
            length ?? stored?.Length ?? 0,
            hasSpaceBetweenWall ?? stored?.HasSpaceBetweenWall ?? false,
            minimumHeight ?? stored?.MinimumHeight,
            maximumHeight ?? stored?.MaximumHeight,
            spacingTop ?? stored?.SpacingTop,
            spacingBottom ?? stored?.SpacingBotton,
            spacingRight ?? stored?.SpacingRight,
            spacingLeft ?? stored?.SpacingLeft);

        var usedM2 = warehouse.Sections.Sum(s => s.SectionCapacity?.UsableAreaM2 ?? 0);
        capacity.UnusedSpaceM2 = Math.Max(0, capacity.AvailableSpaceWithSpacingM2 - usedM2);

        return new CalculateWarehouseResult(capacity);
    }

    public Task DeleteWarehouseAsync(Guid warehouseId, CancellationToken ct = default)
        => Task.CompletedTask;
}