using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class RackPositions : BasePositionsPallets
{
    public Guid RackId { get; set; }
    public virtual Racks Rack { get; set; } = null!;

    public virtual ICollection<StockPlacements> StockPlacements { get; set; } = [];
}