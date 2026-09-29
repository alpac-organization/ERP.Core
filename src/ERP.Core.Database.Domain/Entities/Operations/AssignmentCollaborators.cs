using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Domain.Entities.Auth;

namespace ERP.Core.Database.Domain.Entities.Operations
{
    public class AssignmentCollaborators : BaseEntity<Guid>
    {
        public bool IsActive { get; set; } = true;
        
        public Guid CreatedByUserId { get; set; }
        public virtual User User { get; set; } = default!;

        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = default!;

        public AssignmentCollaboratorsRoles Role { get; set; }
        
        public Guid AssignmentOperationalId { get; set; }
        public virtual AssignmentOperational AssignmentOperational { get; set; } = default!;
    }
}
