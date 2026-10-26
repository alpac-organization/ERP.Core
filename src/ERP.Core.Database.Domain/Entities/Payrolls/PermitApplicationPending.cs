using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class PermitApplicationPending : BaseEntity<Guid>
    {
        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = null!;

        public bool IsActive { get; set; }
        public string? Description { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }

        public PermitApplicationType Type { get; set; }
        public PermitBeneficiaryScope BeneficiaryScope {get; set;} = PermitBeneficiaryScope.None;
        public FamilyRelationship FamilyRelationship {get; set;} = FamilyRelationship.None;
        public string? RelatedPersonName {get; set;} = string.Empty;

        [Column(TypeName = "jsonb")] 
        public string AdditionalData { get; set; } = "{}";

        public string? RequestedBy { get; set; }
    }
}