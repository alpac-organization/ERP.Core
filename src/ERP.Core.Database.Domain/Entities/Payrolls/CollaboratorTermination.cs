using System.ComponentModel.DataAnnotations.Schema;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
   public class CollaboratorTermination : BaseEntity<Guid>
   {
      public Guid CollaboratorId { get; set; }
      public virtual Collaborator Collaborator { get; set; } = null!;

      public Guid? SanctionId { get; set; }
      public virtual DisciplinarySanction? DisciplinarySanction { get; set; }

      // Fecha efectiva de baja: CollaboratorPeriod.DepartureDate
      public virtual CollaboratorPeriod? EmploymentPeriod { get; set; }

      // Ambos Notice* son opcionales
      public DateOnly? NoticeDate { get; set; } // Día en que se notificó/avisó por escrito la terminacion (no el último día de trabajo)

      public int? NoticeDays { get; set; } // Días de anticipacion registrados (referencia típica 15 días en renuncia de contrato indeterminado, aun que, puede ser diferente)

      public string Reason { get; set; } = string.Empty;

      public TerminationType TerminationType { get; set; }

      public TerminationProcessStatus TerminationStatus { get; set; }

      public Guid RegisteredBy { get; set; }
      public virtual User RegisteredByUser { get; set; } = null!;

      public Guid? ClosedBy { get; set; }
      public virtual User? ClosedByUser { get; set; }

      public DateTime? ClosedAt { get; set; }

      public string? CancellationReason { get; set; }

      [Column(TypeName = "jsonb")]
      public string Evidence { get; set; } = "{}";
   }
}
