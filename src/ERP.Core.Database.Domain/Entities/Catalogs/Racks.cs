using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;
namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class Racks : BaseEntity<Guid>
{
   public string Code { get; set; } = null!;

   public Guid SectionId { get; set; }
   public virtual Sections Section { get; set; } = null!;
   
   public virtual RackCapacity RackCapacity { get; set; } = null!;

   public RackUsageProfile UsageProfile { get; set; }
   public int RowNumber { get; set; }
   public int LevelNumber { get; set; }
   public int MaxPulleys { get; set; } = 2;

   public string? UnavailableReason { get; set; }
   public DateTime? StatusChangedAt { get; set; }
   public RackStatus Status { get; set; } = RackStatus.Available;

   public virtual ICollection<RackPositions> Positions { get; set; } = [];
   public virtual ICollection<WarehouseAssignments> Assignments { get; set; } = [];
}