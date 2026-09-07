using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class WarehouseTaskOwnershipLog : BaseEntity<Guid>
{
    public Guid WarehouseTaskId { get; set; }
    public virtual WarehouseTask WarehouseTask { get; set; } = null!;

    public string? PreviousOwnerUserId { get; set; }
    public string NewOwnerUserId { get; set; } = null!;
    public string TransferredByUserId { get; set; } = null!;
    public DateTime TransferredAt { get; set; }
}
