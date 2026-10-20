using System.ComponentModel.DataAnnotations.Schema;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
   public class DisciplinaryFault : BaseEntity<Guid>
   {
      public Guid CollaboratorId { get; set; }
      public virtual Collaborator Collaborator { get; set; } = null!;

      public Guid FaultCatalogId { get; set; }
      public virtual FaultCatalog FaultCatalog { get; set; } = null!;
      public DateOnly OccurrenceDate { get; set; }

      public FaultSeverity Severity { get; set; }
      public FaultSource Source { get; set; }
      public FaultStatus Status { get; set; }

      public Guid RegisteredBy { get; set; }
      public Guid? ParentFaultId { get; set; }
      public virtual DisciplinaryFault? ParentFault { get; set; }

      /// <summary>
      /// Evidencias en JSON (notas + fotos en S3). Default "{}".
      /// </summary>
      [Column(TypeName = "jsonb")]
      public string Evidence { get; set; } = "{}";

      public virtual ICollection<DisciplinarySanction> Sanctions { get; set; } = [];
      public virtual ICollection<Absence> Absences { get; set; } = [];
   }
}