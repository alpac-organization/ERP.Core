using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class InventoryOutputs : BaseEntity<Guid>
    {
        public string Code { get; set; } = null!;
        public string? Observations { get; set; }
        public InventoryOutputsStatus Status { get; set; }

        public Guid BranchId { get; set; }
        public virtual Branch Branch { get; set; } = default!;

        public Guid WorkAreaId { get; set; }
        public virtual WorkArea WorkArea { get; set; } = default!;

        public Guid CostCenterId { get; set; }
        public virtual CostCenter CostCenter { get; set; } = default!;

        public Guid? SupplyRequestId { get; set; }
        public virtual SupplyRequest SupplyRequest { get; set; } = default!;

        public Guid? FuelRequestId { get; set; }
        public virtual FuelRequest FuelRequest { get; set; } = default!;

        public Guid ReasonsInventoryRemovalId { get; set; }
        public virtual ReasonsInventoryRemoval ReasonsInventoryRemoval { get; set; } = default!;

        public Guid? DispatchedByUserId { get; set; }
        public virtual User? User { get; set; }
        public DateTime? DispatchedAt { get; set; }
        public string? DispatchedJustification { get; set; }
        public bool? IsAllDispached { get; set; } = true;
        public virtual ICollection<InventoryOutputsItem> InventoryOutputsItems { get; set; } = [];
    }
}