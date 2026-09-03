using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class UnloadingPositionReservations : BaseEntity<Guid>
{
    public Guid EntranceDucatId { get; set; }
    public Guid WarehouseAssignmentId { get; set; }
    public Guid WarehouseId { get; set; }
    public Guid? UnloadingDetailsId { get; set; }
    public Guid? RackPositionId { get; set; }
    public Guid? LotPositionId { get; set; }
    public int Quantity { get; set; }
    public string ReservedByUserId { get; set; } = null!;
    public DateOnly ReservedAtDate { get; set; }
    public TimeOnly ReservedAtTime { get; set; }

    public virtual WarehouseAssignments WarehouseAssignment { get; set; } = null!;
}