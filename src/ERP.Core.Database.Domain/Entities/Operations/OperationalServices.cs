using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Operations
{
    public class OperationalService : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public string? ServiceCode { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<ServicesOrder> ServicesOrders { get; set; } = [];
    }
}