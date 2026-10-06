using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class LotsPositionsCoordinates : BaseCoordinates
{
    public Guid LotPositionId { get; set; }
    public virtual LotsPositions LotPosition { get; set; } = null!;
}