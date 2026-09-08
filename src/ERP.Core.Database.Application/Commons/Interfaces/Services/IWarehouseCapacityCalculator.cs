using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Services;

public interface IWarehouseCapacityCalculator
{
    RackCapacity CalculateRack(decimal width, decimal length, decimal? height);
    LotsCapacity CalculateLot(decimal width, decimal length);
    SectionCapacity CalculateSection(decimal width, decimal length,
        IEnumerable<RackCapacity> racks, IEnumerable<LotsCapacity> lots);
    WarehouseCapacity CalculateWarehouse(decimal width, decimal length,
        bool hasSpaceBetweenWall,
        decimal? minimumHeight, decimal? maximumHeight,
        decimal? spacingTop, decimal? spacingBottom,
        decimal? spacingRight, decimal? spacingLeft,
        IEnumerable<SectionCapacity> sections);
}