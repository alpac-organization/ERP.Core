using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class ProductStock : BaseEntity<Guid>
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;

        public virtual ICollection<SupplyRequestItem> SupplyRequestItems { get; set; } = [];
    }
}