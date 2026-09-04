using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Domain.ValueObjects;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class Sections : BaseEntity<Guid>
{
   public string Code { get; set; } = null!;
   public string Name { get; set; } = null!;
   public SectionType SectionType { get; set; }
   public SectionStorageType StorageType { get; set; } = SectionStorageType.Empty;
   public bool IsActive { get; set; } = true;

   public decimal WidthMetres { get; set; }
   public decimal LengthMetres { get; set; }

   public TransformWarehouse3D TransformWarehouse3D { get; set; } = new();
   public Guid WarehouseId { get; set; }
   public virtual Warehouses Warehouse { get; set; } = null!;

   public virtual SectionOverflowCapacity? OverflowCapacity { get; set; }
   public virtual SectionCapacity? Capacity { get; set; }

   public virtual ICollection<Lots> Lots { get; set; } = [];
    public virtual ICollection<Racks> Racks { get; set; } = [];
    public virtual ICollection<WarehouseAssignments> Assignments { get; set; } = [];
}