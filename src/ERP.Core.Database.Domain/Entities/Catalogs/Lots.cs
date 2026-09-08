using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
   public class Lots : BaseEntity<Guid>
   {
      public int NominalRows { get; set; }
      public int NominalColumns { get; set; }
      public bool AllowsStacking { get; set; } = true!;

      public string Code { get; set; } = null!;

      public RackStatus Status { get; set; }
      public string? UnavailableReason { get; set; }
      public DateTime? StatusChangedAt { get; set; }

      public virtual LotsCapacity LotsCapacity { get; set; } = default!;

      public Guid SectionId { get; set; }
      public virtual Sections Section { get; set; } = null!;

      public virtual ICollection<LotsPositions> Positions { get; set; } = [];
      public virtual ICollection<WarehouseAssignments> Assignments { get; set; } = [];
   }
}