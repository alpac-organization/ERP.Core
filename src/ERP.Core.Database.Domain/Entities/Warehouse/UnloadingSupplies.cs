using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class UnloadingSupplies : BaseEntity<Guid>
{
    public Guid UnloadingDetailsId { get; set; }
    public string Description { get; set; } = null!;
    public decimal Quantity { get; set; }

    public virtual UnloadingDetails UnloadingDetails { get; set; } = null!;
}