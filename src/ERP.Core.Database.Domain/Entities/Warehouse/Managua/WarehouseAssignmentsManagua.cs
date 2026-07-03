using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class WarehouseAssignmentsManagua : BaseEntity<Guid>
{
    // Relación 1:1 - Llave primaria y foránea al mismo tiempo
    public Guid RecordEntranceManaguaId { get; set; }

    public Guid WarehouseId { get; set; }
    public Guid? ZoneId { get; set; }
    public Guid RackId { get; set; }
    public DateTime AssignedAt { get; set; }
    public string AssignedByUserId { get; set; } = null!;

    // Propiedades de navegación
    public virtual RecordEntranceManagua RecordEntranceManagua { get; set; } = null!;
    public virtual Warehouses Warehouse { get; set; } = null!;
    public virtual RacksManagua Rack { get; set; } = null!;
    public virtual ZonesManagua Zone { get; set; } = null!;

    public virtual UnloadingDetailsManagua? UnloadingDetails { get; set; }
}