using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class UnloadingSupplies : BaseEntity<Guid>
{
    public Guid UnloadingDetailsId { get; set; }
    public Guid SuppliesId { get; set; }
    public decimal Quantity { get; set; }

    public virtual UnloadingDetails UnloadingDetails { get; set; } = null!;
    public virtual Supplies Supplies { get; set; } = null!;
}