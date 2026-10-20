using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
   public class Absence : BaseEntity<Guid>
   {
      public Guid CollaboratorId { get; set; }
      public virtual Collaborator Collaborator { get; set; } = null!;

      public DateOnly Date { get; set; } // Fecha exacta del día no laborado

      public AbsenceStatus Status { get; set; } = AbsenceStatus.Pending;

      public AbsenceSource Source { get; set; } = AbsenceSource.BiometricClock; // Fuente de la inasistencia 

      public string? Reason { get; set; } // Motivo u observación inicial

      public Guid RegisteredBy { get; set; } // Usuario que reportó la inasistencia (Jefe inmediato o ID Sistema si es por reloj)

      public Guid? ReviewedBy { get; set; } // Usuario de RRHH que aplicó o canceló la inasistencia

      public DateTime? ReviewedAt { get; set; } // Fecha y hora en que RRHH revisó (aplicó o canceló)

      public string? CancellationReason { get; set; } // Motivo si RRHH la cancela (ej. Negociación externa: aplicado a vacaciones o permiso)

      public decimal SalaryDeduction { get; set; } = 0.0m; // Deducción de día de salario ordinario
      public decimal SeventhDayDeduction { get; set; } = 0.0m; // Deducción de séptimo día por inasistencia
      public decimal TravelExpensesDeduction { get; set; } = 0.0m; // Deducción de viáticos no devengados (transporte, comida)

      public decimal TotalDeduction => SalaryDeduction + SeventhDayDeduction + TravelExpensesDeduction;

      // Vínculo con la nómina
      public Guid? PayrollId { get; set; }
      public virtual Payroll? Payroll { get; set; }

      // Vínculo con la nómina ordinaria
      public Guid? OrdinaryPayrollId { get; set; }
      public virtual OrdinaryPayroll? OrdinaryPayroll { get; set; }

      // Vínculo con la faltas
      public Guid? DisciplinaryFaultId { get; set; }
      public virtual DisciplinaryFault? DisciplinaryFault { get; set; }
   }
}
