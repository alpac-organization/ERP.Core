using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class RackPositions : BaseEntity<Guid>
{
    public Guid RackId { get; set; }
    public virtual Racks Rack { get; set; } = null!;

    public int PositionNumber { get; set; } // 1, 2 (según MaxPulleys)

    public string PositionCode { get; set; } = null!;

    public bool IsBlocked { get; set; } = false;
    public bool IsOccupied { get; set; } = false;
    public bool IsReserved { get; set; } = false;
    public string? BlockReason { get; set; }

    public virtual ICollection<WarehouseAssignments> Assignments { get; set; } = [];
    public virtual ICollection<Stocks> CurrentStock { get; set; } = [];
}