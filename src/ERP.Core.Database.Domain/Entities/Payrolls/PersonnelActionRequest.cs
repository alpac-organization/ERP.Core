using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class PersonnelActionRequest : BaseEntity<Guid>
    {
        public string RequestCode { get; set; } = null!;
        public PersonnelActionScope Scope { get; set; }
        public PersonnelActionStatus Status { get; set; }

        public DateTime EffectiveDate { get; set; }
        public string Justification { get; set; } = null!;
        public string? AttachmentUrl { get; set; }

        public Guid RequestedByUserId { get; set; }
        public DateTime RequestedAt { get; set; }

        public Guid? ReviewedByManagementUserId { get; set; }
        public DateTime? ReviewedByManagementAt { get; set; }
        public string? ManagementNotes { get; set; }

        public Guid? AppliedByUserId { get; set; }
        public DateTime? AppliedAt { get; set; }

        public virtual ICollection<PersonnelActionRequestItem> Items { get; set; } = [];
    }
}
