
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
   public class DisciplinarySanction : BaseEntity<Guid>
   {
      public Guid FaultId { get; set; }
      public virtual DisciplinaryFault Fault { get; set; } = null!;

      public string Code { get; set; } = string.Empty;

      public SanctionType SanctionType { get; set; }

      public SanctionStatus SanctionStatus { get; set; }

      public DateOnly? SuspensionStartDate { get; set; }

      public DateOnly? SuspensionEndDate { get; set; }

      public Guid? PayrollId { get; set; }
      public virtual Payroll? Payroll { get; set; }

      public string Reason { get; set; } = string.Empty;
      public string? CancellationReason { get; set; } // Motivo si SanctionStatus = Cancelled (rechazo/cancelación)

      public Guid IssuedBy { get; set; } // Quién crea/propone la sanción (Jefe Inmediato)
      public virtual User User { get; set; } = null!;

      public Guid? ApprovedBy { get; set; } // Quién aprueba/aplica la sanción (Recursos Humanos)
      public virtual User? ApprovedByUser { get; set; }

      public DateTime? ApprovedAt { get; set; } // Fecha/hora de aprobación

      /// <summary>
      /// Documentos de la sancion (Memorandum o Memorandum + Carta de Compromiso, Carta de Cancelacion + Autorizacion MITRAB si se requiere)
      /// </summary>
      [Column(TypeName = "jsonb")]
      public string Evidence { get; set; } = "{}";
   }
}
