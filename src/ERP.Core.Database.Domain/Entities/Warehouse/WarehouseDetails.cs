using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class WarehouseDetails : BaseEntity<Guid>
{
    public Guid WarehouseId { get; set; }
    public decimal TotalCubicCapacity { get; set; }
    public decimal TotalArea { get; set; }
    public decimal NetStorageArea { get; set; }
    public decimal UnusableArea { get; set; }
    public decimal MaxHeight { get; set; }
    public decimal MinHeight { get; set; }
    public int RampasCount { get; set; }
    public int ParkingSpacesCount { get; set; }

    public virtual Warehouses Warehouses { get; set; } = null!;
}