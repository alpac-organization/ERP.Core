using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class SectionPositions : BasePositionsPallets
{
    public Guid SectionId { get; set; }
    public virtual Sections Section { get; set; } = null!;

    public virtual ICollection<AssignmentStockPlacements> AssignmentStockPlacements { get; set; } = [];

}