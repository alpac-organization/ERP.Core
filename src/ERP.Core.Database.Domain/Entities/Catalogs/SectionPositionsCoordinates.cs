using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class SectionPositionsCoordinates : BaseCoordinates
{
    public Guid SectionPositionId { get; set; }
    public virtual SectionPositions SectionPosition { get; set; } = null!;
}
