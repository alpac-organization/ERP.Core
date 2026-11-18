using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class PersonnelActionRequestItem : BaseEntity<Guid>
    {
        public Guid PersonnelActionRequestId { get; set; }
        public virtual PersonnelActionRequest PersonnelActionRequest { get; set; } = null!;

        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = null!;

        public Guid? SalaryId { get; set; }
        public virtual Salary? Salary { get; set; }

        public Guid? WorkPositionHistoryId { get; set; }
        public virtual WorkPositionHistory? WorkPositionHistory { get; set; }

        public string? MemorandumUrl { get; set; }
    }
}
