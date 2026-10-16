
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
   public class FaultCatalog : BaseEntity<Guid>
   {
      public Guid CompanyId { get; set; }
      public virtual Company Company { get; set; } = null!;

      public string Code { get; set; } = string.Empty;
      public string Name { get; set; } = string.Empty;
      public string Description { get; set; } = string.Empty;
      public bool IsActive { get; set; }
      public FaultSeverity FaultSeverity { get; set; }

      public virtual ICollection<DisciplinaryFault> DisciplinaryFaults { get; set; } = [];
   }
}