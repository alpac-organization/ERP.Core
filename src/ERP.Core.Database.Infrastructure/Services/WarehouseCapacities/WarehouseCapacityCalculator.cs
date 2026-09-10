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
        bool hasMargins,
        decimal? minimumHeight, decimal? maximumHeight,
        decimal? marginTop, decimal? marginBottom,
        decimal? marginRight, decimal? marginLeft,
        CancellationToken ct = default)
    {
        var capacity = BuildWarehouseCapacity(width, length, hasMargins,
            minimumHeight, maximumHeight,
            marginTop, marginBottom, marginRight, marginLeft,
            sections: []);

        return Task.FromResult(new CalculateWarehouseResult(capacity));
    }

    public async Task<CalculateWarehouseResult> UpdateWarehouseAsync(
        Guid warehouseId,
        decimal? width, decimal? length,
        bool? hasMargins,
        decimal? minimumHeight, decimal? maximumHeight,
        decimal? marginTop, decimal? marginBottom,
        decimal? marginRight, decimal? marginLeft,
        CancellationToken ct = default)
    {
        var warehouse = await UnitOfWork.Warehouses.Entities
            .AsNoTracking()
            .Include(w => w.WarehouseCapacity)
            .Include(w => w.Sections.Where(s => s.DeletedAt == null)).ThenInclude(s => s.SectionCapacity)
            .FirstOrDefaultAsync(w => w.Id == warehouseId, ct);
        if (warehouse is null)
            return new CalculateWarehouseResult(null);

        var stored = warehouse.WarehouseCapacity;

        var capacity = BuildWarehouseCapacity(
            width ?? stored?.Width ?? 0,
            length ?? stored?.Length ?? 0,
            hasMargins ?? stored?.HasMargins ?? false,
            minimumHeight ?? stored?.MinimumHeight,
            maximumHeight ?? stored?.MaximumHeight,
            marginTop ?? stored?.MarginTop,
            marginBottom ?? stored?.MarginBottom,
            marginRight ?? stored?.MarginRight,
            marginLeft ?? stored?.MarginLeft,
            warehouse.Sections.Select(s => new EffectiveSection(
                s.SectionCapacity, s.SectionType, s.SectionStorageType)));

        return new CalculateWarehouseResult(capacity);
    }

    public Task DeleteWarehouseAsync(Guid warehouseId, CancellationToken ct = default)
        => Task.CompletedTask;
}