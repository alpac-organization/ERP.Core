using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Domain.Entities.Operations
{
    public class ServicesOrder : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }

        public string? Concept { get; set; }
        public string? ServiceOrderCode { get; set; }

        public Guid CreatedByUserId { get; set; }
        public virtual User User { get; set; } = default!;

        public Guid OperationalServiceId { get; set; }
        public virtual OperationalService OperationalService { get; set; } = default!;
        
        public Guid OperationalOrderId { get; set; }
        public virtual OperationalOrder OperationalOrder { get; set; } = default!;

        public virtual ICollection<ServiceOrderRequistions> ServiceOrderRequistions { get; set; } = [];
    }
    
}