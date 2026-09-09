using ERP.Core.Database.Domain.ValueObjects;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
   public class Sections : BaseEntity<Guid>
   {
      public string? Code { get; set; }
      public bool IsActive { get; set; } = true;
      public SectionType SectionType { get; set; }

      public virtual SectionCapacity SectionCapacity { get; set; } = default!;
      public virtual SectionStorageType SectionStorageType { get; set; } = default!;

      public Guid WarehouseId { get; set; }
      public virtual Warehouses Warehouse { get; set; } = null!;

      /// <summary>
      /// Tramos y racks que perteneces a la sección como tal
      /// </summary>
      public virtual ICollection<Lots> Lots { get; set; } = [];
      public virtual ICollection<Racks> Racks { get; set; } = [];
   }
}