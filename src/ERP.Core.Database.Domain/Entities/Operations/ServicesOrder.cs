using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Operations
{
    public class ServicesOrder : BaseEntity<Guid>
    {
        public string? ServiceOrderCode { get; set; }
        
        public Guid OperationalServiceId { get; set; }
        public virtual OperationalService? OperationalService { get; set; } = default!; 

        public Guid OperationalOrderId { get; set; }
        public virtual OperationalOrder OperationalOrder { get; set; } = default!;
    }
}