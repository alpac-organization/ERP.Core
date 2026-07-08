using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse_MNG;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class Warehouses : BaseEntity<Guid>
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public bool IsOwner { get; set; } = true;

    //Capacidad volumetrica total de la bodega
    public decimal TotalCubicCapacity { get; set; }

    //Seccion metrica e infraestructura
    public WarehouseType WarehouseType { get; set; }
    public decimal TotalArea { get; set; }
    public decimal NetStorageArea { get; set; }
    public decimal UnusableArea { get; set; }
    public decimal MaxHeight { get; set; }
    public decimal MinHeight { get; set; }
    public decimal RampasCount { get; set; }
    public decimal ParkingSpacesCount { get; set; }

    //Relacion autorreferencial (para bodegas que tienen galerones techados)
    public Guid? ParentWarehouseId { get; set; }
    public virtual Warehouses? ParentWarehouse { get; set; }
    public virtual ICollection<Warehouses> SubWarehouses { get; set; } = [];

    //Relaciones
    public Guid BranchId { get; set; }
    public virtual Branch Branch { get; set; } = null!;

    //Coleccion del layout
    public virtual ICollection<ZonesManagua> Zones { get; set; } = [];


}