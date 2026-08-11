using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class WarehouseCapacity : BaseEntity<Guid>
{
    public Guid WarehouseId { get; set; }

    public decimal TotalAreaM2 { get; set; }
    public decimal? UsableAreaM2 { get; set; }
    public decimal? UnusableAreaM2 { get; set; }

    public int? TotalMaxPolines { get; set; }
    public int? CurrentPolinesStored { get; set; }

    public DateTime? LastCalculatedAt { get; set; }

    public virtual Warehouses Warehouse { get; set; } = null!;
}