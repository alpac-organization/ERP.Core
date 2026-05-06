using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class Subsidy : BaseEntity<Guid>
    {
        public Guid CollaboratorId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? ReferenceNumber { get; set; } // Número de boleta

        public decimal Percentage { get; set; } // Campo se agrega por trazabilidad

        public SubsidyType SubsidyType { get; set; }

        public string? Observations { get; set; }

        public virtual Collaborator Collaborator { get; set; } = null!;
    }
}