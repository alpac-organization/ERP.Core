using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class InventoryOutputs : BaseEntity<Guid>
    {
        public string? Code { get; set; }
        public string? Observations { get; set; }

        public Guid BranchId { get; set; }
        public virtual Branch Branch { get; set; } = default!;

        public Guid WorkAreaId { get; set; }
        public virtual WorkArea WorkArea { get; set; } = default!;

        public Guid CostCenterId { get; set; }
        public virtual CostCenter CostCenter { get; set; } = default!;

        public Guid SupplyRequestId { get; set; }
        public virtual SupplyRequest SupplyRequest { get; set; } = default!;

        public Guid ReasonsInventoryRemovalId { get; set; }
        public virtual ReasonsInventoryRemoval ReasonsInventoryRemoval { get; set; } = default!;
    }
}