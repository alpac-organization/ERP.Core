using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class UnloadingDetails : BaseEntity<Guid>
{
    public Guid RecordEntranceId { get; set; }
    public Guid WarehouseAssignmentsId { get; set; }
    public DateTime UnloadingStartTime { get; set; }
    public DateTime? UnloadingEndTime { get; set; }
    public string WarehouseChiefUserId { get; set; } = null!;
    public decimal? PreparedPallets { get; set; } //saber cuantos pallets armaron en total

    // Propiedades de navegación
    public virtual RecordEntrance RecordEntrance { get; set; } = null!;
    public virtual WarehouseAssignments WarehouseAssignments { get; set; } = null!;

    public virtual ICollection<UnloadingCrewAssignments> CrewAssignments {get;set;} = [];
    public virtual ICollection<UnloadingMachineryAssignments> MachineryAssignments {get;set;} = [];
}