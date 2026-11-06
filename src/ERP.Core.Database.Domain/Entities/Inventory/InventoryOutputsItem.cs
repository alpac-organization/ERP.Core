using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Inventory;

public class InventoryOutputsItem : BaseEntity<Guid>
{
    public Guid InventoryOutputId { get; set; }
    public virtual InventoryOutputs InventoryOutput { get; set; } = default!;

    public Guid ProductStockId { get; set; }
    public virtual ProductStock ProductStock { get; set; } = default!;

    public decimal DispatchedQuantity { get; set; }
}