using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class Subsidy : BaseEntity<Guid>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public int AmountDays { get; set; }
        public decimal Percentage { get; set; }     
        public string? ReferenceNumber { get; set; }
        public string? Observations { get; set; }


        public Guid PayrollId { get; set; }
        public virtual Payroll Payroll { get; set; } = null!;

        public Guid TypeSubsidyId { get; set; }
        public virtual TypesSubsidy TypesSubsidy { get; set; } = null!;

        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = null!;
    }
}
