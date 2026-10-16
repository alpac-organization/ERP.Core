
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
   public class DisciplinarySanction : BaseEntity<Guid>
   {
      public Guid FaultId { get; set; }
      public virtual DisciplinaryFault Fault { get; set; } = null!;

      public SanctionType SanctionType { get; set; }

      public SanctionStatus SanctionStatus { get; set; }

      public DateOnly? SuspensionStartDate { get; set; }

      public DateOnly? SuspensionEndDate { get; set; }

      public Guid? PayrollId { get; set; }
      public virtual Payroll? Payroll { get; set; }

      public string Reason { get; set; } = string.Empty;

      public Guid IssuedBy { get; set; } // Quién aplicó la sanción (Jefe Inmediato o Recursos Humanos)

      /// <summary>
      /// Documentos de la sancion (Memorandum o Memorandum + Carta de Compromiso, Carta de Cancelacion + Autorizacion MITRAB si se requiere)
      /// </summary>
      [Column(TypeName = "jsonb")]
      public string Evidence { get; set; } = "{}";
   }
}