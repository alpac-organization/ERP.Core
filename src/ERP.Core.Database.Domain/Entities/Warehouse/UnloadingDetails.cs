using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class UnloadingDetails : BaseEntity<Guid>
{
    public Guid WarehouseAssignmentId { get; set; }
    public UnloadingMerchandiseType MerchandiseType { get; set; }

    public virtual WarehouseAssignments WarehouseAssignment { get; set; } = null!;
    public virtual ICollection<UnloadingPallets> UnloadingPallets { get; set; } = [];
    public virtual ICollection<UnloadingSupplies> UnloadingSupplies { get; set; } = [];
}