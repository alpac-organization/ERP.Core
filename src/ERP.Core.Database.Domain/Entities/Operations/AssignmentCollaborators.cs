using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Domain.Entities.Operations;

public class AssignmentCollaborators : BaseEntity<Guid>
{
    public Guid OperationalOrderId { get; set; }
    public virtual OperationalOrder OperationalOrder { get; set; } = default!;

    public Guid CollaboratorId { get; set; }
    public virtual Collaborator Collaborator { get; set; } = default!;

    public AssignmentCollaboratorsRoles Role { get; set; } = AssignmentCollaboratorsRoles.WarehouseAssistant;

    public bool IsActive { get; set; } = true;
}