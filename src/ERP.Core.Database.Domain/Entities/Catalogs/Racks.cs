using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class Racks : BaseEntity<Guid>
{
    public Guid SectionId { get; set; }
    public virtual Sections Section { get; set; } = null!;

    public string Code { get; set; } = null!;
    public decimal WidthMetres { get; set; }
    public decimal LengthMetres { get; set; }
    public decimal? HeightMetres { get; set; }
    public decimal PositionX { get; set; }
    public decimal PositionY { get; set; }
    public decimal PositionZ { get; set; }
    public decimal RotationY { get; set; }

    public RackUsageProfile UsageProfile { get; set; }
    public int RowNumber { get; set; }
    public int LevelNumber { get; set; }
    public int MaxPulleys { get; set; } = 2;

    public RackStatus Status { get; set; } = RackStatus.Available;
    public string? UnavailableReason { get; set; }
    public DateTime? StatusChangedAt { get; set; }

    public virtual ICollection<RackPositions> Positions { get; set; } = [];
    public virtual ICollection<WarehouseAssignments> Assignments { get; set; } = [];
}