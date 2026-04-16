using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class Deduction : BaseEntity<Guid>
    {
        public DeductionType Type { get; set; }
        public string? Description { get; set; }
        public Guid CollaboratorId { get; set;}
        public virtual Collaborator Collaborator { get; set; } = null!;
    }
}