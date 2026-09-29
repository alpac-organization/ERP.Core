using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Operations
{
    public class AssignmentsMachinery : BaseEntity<Guid>
    {
        public string? Concept { get; set; }
        public bool IsActive { get; set; } = true;
        
        public Guid CreatedByUserId { get; set; }
        public virtual User User { get; set; } = default!;

        public Guid MachineryId { get; set; }
        public virtual Machinery Machinery { get; set; } = default!;

        public Guid AssignmentOperationalId { get; set; }
        public virtual AssignmentOperational AssignmentOperational { get; set; } = default!;
    }
}

