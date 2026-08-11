using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class WarehouseAssignments : BaseEntity<Guid>
{
    // Relación 1:1 - Llave primaria y foránea al mismo tiempo
    public Guid RecordEntranceId { get; set; }

    public Guid WarehouseId { get; set; }
    public Guid? SectionId { get; set; }
    public Guid RackId { get; set; }
    public DateTime AssignedAt { get; set; }
    public string AssignedByUserId { get; set; } = null!;

    // Propiedades de navegación
    public virtual RecordEntrance RecordEntrance { get; set; } = null!;
    public virtual Warehouses Warehouse { get; set; } = null!;
    public virtual Racks Rack { get; set; } = null!;
    public virtual Sections? Section { get; set; } = null!;

    public virtual UnloadingDetails? UnloadingDetails { get; set; }
}