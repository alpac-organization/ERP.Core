using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class SupplyRequestItem : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        
        public Guid ProductStockId { get; set; }
        public virtual ProductStock ProductStock { get; set; } = default!;
        
        public int Amount { get; set; }
        public ReasonUse ReasonUse { get; set; }

        public Guid SupplyRequestId { get; set; }
        public virtual SupplyRequest SupplyRequest { get; set; } = default!;
    }
}