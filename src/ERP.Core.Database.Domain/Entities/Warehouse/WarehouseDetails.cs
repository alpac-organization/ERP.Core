using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class WarehouseDetails : BaseEntity<Guid>
{
    public Guid WarehouseId { get; set; }

    public decimal WitdhMetres { get; set; }
    public decimal LengthMetres { get; set; }
    public int? RampsCount { get; set; }
    public int? ParkingSpacesCount { get; set; }

    public virtual Warehouses Warehouse { get; set; } = null!;
}