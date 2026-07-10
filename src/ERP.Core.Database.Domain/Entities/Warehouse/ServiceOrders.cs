using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse
{
    public class ServiceOrder : BaseEntity<Guid>
    {
        public string Code { get; set; } = null!;
        public OSStatus Status { get; set; }
        public string? Observations {get; set;}

        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = default!;
    }
}