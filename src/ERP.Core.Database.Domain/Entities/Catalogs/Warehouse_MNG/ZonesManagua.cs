using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs.Warehouse_MNG;

public class ZonesManagua : BaseEntity<Guid>
{
    public Guid WarehouseId { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;

    // Propiedades de navegación estructurales
    public virtual Warehouses Warehouses { get; set; } = null!;
    public virtual ICollection<RacksManagua> Racks { get; set; } = [];
}