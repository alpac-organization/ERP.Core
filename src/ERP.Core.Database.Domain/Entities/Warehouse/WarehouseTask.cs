using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class WarehouseTask : BaseEntity<Guid>
{
    public Guid WarehouseId { get; set; }
    public virtual Warehouses Warehouse { get; set; } = null!;

    public WarehouseTaskType TaskType { get; set; }
    public Guid SourceId { get; set; }
    public WarehouseTaskStatus Status { get; set; } = WarehouseTaskStatus.InProgress;

    public string? CurrentOwnerUserId { get; set; }
    public string CreatedByUserId { get; set; } = null!;

    public DateTime? StartedAt { get; set; }
    public DateTime? PausedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime? CancelledAt { get; set; }
    public DateTime? ClosedAt { get; set; }

    public virtual ICollection<WarehouseTaskEvent> Events { get; set; } = [];
    public virtual ICollection<WarehouseTaskOwnershipLog> OwnershipLogs { get; set; } = [];
}
