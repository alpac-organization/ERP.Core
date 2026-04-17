using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
   public class SalaryAccumulator : BaseEntity<Guid>
   {
      // IR retenido en Nicaragua
      public decimal IncomeTax { get; set; }

      // Acumulador devengado
      public decimal AccruedEarnings { get; set; }

      // Quincena
      public int Fortnight { get; set; }

      public string? Year { get; set; }

      public string? Month { get; set; }

      // Ingresos
      public decimal Revenue { get; set; }

      // Relacion
      public Guid CollaboratorId { get; set; }

      public virtual Collaborator Collaborator { get; set; } = default!;
   }
}