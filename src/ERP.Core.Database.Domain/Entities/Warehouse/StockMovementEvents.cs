using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class StockMovementEvents : BaseEntity<Guid>
{
    public Guid ReassignmentSessionId { get; set; }
    public virtual ReassignmentSessions Session { get; set; } = null!;

    public Guid ReassignmentMemoryItemId { get; set; }
    public virtual ReassignmentMemoryItems MemoryItem { get; set; } = null!;

    public Guid StockId { get; set; }
    public virtual Stocks Stock { get; set; } = null!;

    public DateOnly ConfirmedAtDate { get; set; }
    public TimeOnly ConfirmedAtTime { get; set; }
    public string ConfirmedByUserId { get; set; } = null!;
}