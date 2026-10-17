using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class ProductStock : BaseEntity<Guid>
    {
        

        public virtual ICollection<SupplyRequestItem> SupplyRequestItems { get; set; } = [];
    }
}