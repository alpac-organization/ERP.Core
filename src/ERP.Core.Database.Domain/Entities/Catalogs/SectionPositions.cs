using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class SectionPositions : BasePositionsPallets
{
    public Guid SectionId { get; set; }
    public virtual Sections Section { get; set; } = null!;

    public virtual ICollection<StockPlacements> StockPlacements { get; set; } = [];

}