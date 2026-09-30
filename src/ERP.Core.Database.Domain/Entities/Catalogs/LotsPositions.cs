using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class LotsPositions : BasePositionsPallets
{
    public Guid LotId { get; set; }
    public virtual Lots Lot { get; set; } = null!;

    public virtual ICollection<AssignmentStockPlacements> AssignmentStockPlacements { get; set; } = [];
}