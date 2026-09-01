using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class WarehouseAssignments : BaseEntity<Guid>
{
    public Guid RecordEntranceId { get; set; }
    public Guid? EntranceDucatId { get; set; }
    public Guid WarehouseId { get; set; }
    public Guid? SectionId { get; set; }
    public Guid? RackId { get; set; }
    public Guid? LotsId { get; set; }
    public Guid? LotsPositionsId { get; set; }
    public Guid? RackPositionsId { get; set; }
    public DateTime? UnloadingStartTime { get; set; }
    public DateTime? UnloadingEndTime { get; set; }
    public string? WarehouseKeeperUserId { get; set; }
    public DateTime AssignedAt { get; set; }
    public string AssignedByUserId { get; set; } = null!;

    public UnloadingStatus UnloadingStatus { get; set; } = UnloadingStatus.Pending;

    public virtual RecordEntrance RecordEntrance { get; set; } = null!;
    public virtual EntranceDucats? EntranceDucat { get; set; }
    public virtual Warehouses Warehouse { get; set; } = null!;
    public virtual Racks? Rack { get; set; }
    public virtual Sections? Section { get; set; } = null!;
    public virtual Lots? Lot { get; set; }
    public virtual LotsPositions? LotPosition { get; set; }
    public virtual RackPositions? RackPosition { get; set; }

    public virtual ICollection<CrewAssignments> CrewAssignments { get; set; } = [];
    public virtual ICollection<MachineryAssignments> MachineryAssignments { get; set; } = [];
}