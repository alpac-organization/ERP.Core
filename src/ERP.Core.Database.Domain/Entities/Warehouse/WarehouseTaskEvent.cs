using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class WarehouseTaskEvent : BaseEntity<Guid>
{
    public Guid WarehouseTaskId { get; set; }
    public virtual WarehouseTask WarehouseTask { get; set; } = null!;

    public WarehouseTaskEventType EventType { get; set; }
    public WarehouseTaskStatus? Status { get; set; }
    public string UserId { get; set; } = null!;
    public DateTime OccurredAt { get; set; }
    public string? Notes { get; set; }
}
