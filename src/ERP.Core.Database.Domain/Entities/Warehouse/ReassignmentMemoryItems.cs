using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class ReassignmentMemoryItems : BaseEntity<Guid>
{
    public Guid ReassignmentSessionId { get; set; }
    public virtual ReassignmentSessions Session { get; set; } = null!;

    public Guid StockId { get; set; }
    public virtual Stocks Stock { get; set; } = null!;

    public DateOnly LiftedAtDate { get; set; }
    public TimeOnly LiftedAtTime { get; set; }
    public string LiftedByUserId { get; set; } = null!;

    public DateOnly? ResolvedAtDate { get; set; }
    public TimeOnly? ResolvedAtTime { get; set; }
    public string? ResolvedByUserId { get; set; }

    public virtual ICollection<StockPlacements> OriginPlacements { get; set; } = [];
    public virtual ICollection<StockPlacements> DestinationPlacements { get; set; } = [];
}