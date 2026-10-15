using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Operations;

public class AssignmentStockPlacements : BaseEntity<Guid>
{
    public Guid AssignmentId { get; set; }
    public virtual AssignmentOperational AssignmentOperational { get; set; } = null!;

    public Guid? RackPositionId { get; set; }
    public virtual RackPositions? RackPosition { get; set; }

    public Guid? LotPositionId { get; set; }
    public virtual LotsPositions? LotPosition { get; set; }

    public Guid? SectionId { get; set; }
    public virtual Sections? Section { get; set; }

    public DateTime PlacedAt { get; set; }
    public Guid PlacedByUserId { get; set; }
}