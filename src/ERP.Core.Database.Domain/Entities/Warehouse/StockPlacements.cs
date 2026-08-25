using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class StockPlacements : BaseEntity<Guid>
{
    public Guid StockId { get; set; }
    public virtual Stocks Stock { get; set; } = null!;

    public Guid? RakPositionId { get; set; }
    public virtual RackPositions? RackPosition { get; set; }

    public Guid? LotPositionId { get; set; }
    public virtual LotsPositions? LotsPosition { get; set; }

    public DateOnly PlacetAtDate { get; set; }
    public TimeOnly PlaceAtTime { get; set; }
    public string PlacedByUseId { get; set; } = null!;


    public DateOnly VacatedAtDate { get; set; }
    public TimeOnly VacatedAtTime { get; set; }
    public string VacatedByUseId { get; set; } = null!;

    public Guid? PlacedByMemoryItemId { get; set; }
    public virtual ReassignmentMemoryItems? ReassignmentMemoryItem { get; set; }

    public Guid? VacatedByMemoryItemId { get; set; }
    public virtual ReassignmentMemoryItems? VacatedByMemoryItem { get; set; }
}