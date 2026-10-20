using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class InventoryOutputs : BaseEntity<Guid>
    {
        public string? Code { get; set; }


        public Guid BranchId { get; set; }
        public virtual Branch Branch { get; set; } = default!;
        public Guid WorkAreaId { get; set; }
        public virtual WorkArea WorkArea { get; set; } = default!;


    }
}