using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class RackPositions : BasePositionsPallets
{
    public Guid RackId { get; set; }
    public virtual Racks Rack { get; set; } = null!;

    public virtual ICollection<AssignmentStockPlacements> AssignmentStockPlacements { get; set; } = [];
}