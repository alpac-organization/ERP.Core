using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class Subsidy : BaseEntity<Guid>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? ReferenceNumber { get; set; } // Número de boleta

        public decimal Percentage { get; set; } // Campo se agrega por trazabilidad

        public string? Observations { get; set; }

        public Guid TypeSubsidyId { get; set; }
        public virtual TypesSubsidy TypesSubsidy { get; set; } = null!;

        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = null!;
    }
}
