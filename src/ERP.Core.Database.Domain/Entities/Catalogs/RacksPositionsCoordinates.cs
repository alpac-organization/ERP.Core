using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class RacksPositionsCoordinates : BaseCoordinates
{
    public Guid RackPositionId { get; set; }
    public virtual RackPositions RackPosition { get; set; } = null!;
}