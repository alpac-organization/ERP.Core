using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class ReassignmentSessions : BaseEntity<Guid>
{
    public Guid WarehouseId { get; set; }
    public virtual Warehouses Warehouse { get; set; } = null!;

    public ReassignmentSessionStatus Status { get; set; } = ReassignmentSessionStatus.Open;

    public string CurrentOwnerUserId { get; set; } = null!;

    public DateOnly OpenedAtDate { get; set; }
    public TimeOnly OpenedAtTime { get; set; }
    public string OpenedByUserId { get; set; } = null!;

    public DateOnly? ClosedAtDate { get; set; }
    public TimeOnly? ClosedAtTime { get; set; }

    public virtual ICollection<ReassignmentSessionOwnershipLog> OwnershipLog { get; set; } = [];
    public virtual ICollection<ReassignmentMemoryItems> MemoryItems { get; set; } = [];
}