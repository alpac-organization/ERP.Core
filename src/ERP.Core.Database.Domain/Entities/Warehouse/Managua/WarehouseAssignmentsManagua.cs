using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse_MNG;

namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class WarehouseAssignmentsManagua
{
    // Relación 1:1 - Llave primaria y foránea al mismo tiempo
    public Guid RecordEntranceManaguaId { get; set; }
    public Guid WarehouseId { get; set; }
    public Guid? ZoneId { get; set; }
    public Guid RackId { get; set; }
    public DateTime AssignedAt { get; set; }

    // Propiedades de navegación
    public virtual RecordEntranceManagua RecordEntranceManagua { get; set; } = null!;
    public virtual Warehouses Warehouse { get; set; } = null!;
    public virtual RacksManagua Rack { get; set; } = null!;
}