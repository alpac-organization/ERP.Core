using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Operations
{
    public class AssignmentEnclosure : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public string? Observations { get; set; }
        public string Merchandise { get; set; } = null!;
        public string MerchandiseDescription { get; set; } = null!;
        
        public DestinationType DestinationType { get; set; }

        public Guid? WarehouseId { get; set; }
        public virtual Warehouses Warehouse { get; set; } = default!;

        public Guid AssignmentOperationalId { get; set; }
        public virtual AssignmentOperational AssignmentOperational { get; set; } = default!;
    }
}
