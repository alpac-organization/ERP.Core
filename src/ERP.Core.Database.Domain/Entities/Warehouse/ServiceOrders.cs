using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Warehouse
{
    public class ServiceOrder : BaseEntity<Guid>
    {
        public string Code { get; set; } = null!;
        public bool IsCreatedFromPortal { get; set; } //true, por el cliente, false, por el colaborador
        public OSStatus Status { get; set; } = OSStatus.Pendiente;
        public string? Observations {get; set;}

        public Guid BranchId { get; set; }
        public virtual Branch Branch {get; set;} = default!;

        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = default!;
    }
}