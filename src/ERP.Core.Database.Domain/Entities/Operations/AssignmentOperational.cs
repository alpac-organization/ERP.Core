using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Operations
{
    public class AssignmentOperational : BaseEntity<Guid>
    {
        public bool HasMachineryAssigned { get; set; }
        public bool HasEnclosureAssigned { get; set; }
        public bool HasCollaboratorsAssigned { get; set; }
        
        public AssignmentOperationalStatus Status { get; set; }

        //Navigate
        public Guid OperationalOrderId { get; set; }
        public virtual OperationalOrder OperationalOrder { get; set; } = default!;

        //1:1
        public virtual AssignmentEnclosure AssignmentEnclosure { get; set; } = default!;

        //1:M
        public virtual ICollection<AssignmentsMachinery> AssignmentsMachineries { get; set; } = [];
        public virtual ICollection<AssignmentCollaborators> AssignmentCollaborators { get; set; } = [];

        public string? AdditionalData { get; set; } = "{}";
    }

    public class AdditionalDataAssingmentOperational
    {
        //En espera..   
    }
}