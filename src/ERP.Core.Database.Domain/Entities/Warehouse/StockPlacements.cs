using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class StockPlacements : BaseEntity<Guid>
{
    public Guid StockId { get; set; }
    public virtual Stocks Stock { get; set; } = null!;

    public Guid? RackPositionId { get; set; }
    public virtual RackPositions? RackPosition { get; set; }

    public Guid? LotPositionId { get; set; }
    public virtual LotsPositions? LotPosition { get; set; }

    public DateOnly PlacedAtDate { get; set; }
    public TimeOnly PlacedAtTime { get; set; }
    public string PlacedByUserId { get; set; } = null!;


    public DateOnly? VacatedAtDate { get; set; }
    public TimeOnly? VacatedAtTime { get; set; }
    public string VacatedByUserId { get; set; } = null!;

    public Guid? PlacedByMemoryItemId { get; set; }
    public virtual ReassignmentMemoryItems? PlacedByMemoryItem  { get; set; }

    public Guid? VacatedByMemoryItemId { get; set; }
    public virtual ReassignmentMemoryItems? VacatedByMemoryItem { get; set; }
}