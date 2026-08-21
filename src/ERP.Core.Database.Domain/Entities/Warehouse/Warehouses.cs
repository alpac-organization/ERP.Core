using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class Warehouses : BaseEntity<Guid>
{
    public string Code { get; set; } = null!;
    public string WarehouseName { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public bool IsOwner { get; set; } = true;
    public bool HasChildren { get; set; } = false;
    public WarehouseType WarehouseType { get; set; }


    //Relacion autorreferencial (para bodegas que tienen galerones techados)
    public Guid? ParentWarehouseId { get; set; }
    public virtual Warehouses? ParentWarehouse { get; set; }
    public virtual ICollection<Warehouses> SubWarehouses { get; set; } = [];

    //Relaciones
    public Guid BranchId { get; set; }
    public virtual Branch Branch { get; set; } = null!;

    //Coleccion del layout
    public virtual ICollection<Sections> Sections { get; set; } = [];
    public virtual WarehouseDetails Details { get; set; } = null!;
    public virtual WarehouseCapacity? Capacity { get; set; }
}