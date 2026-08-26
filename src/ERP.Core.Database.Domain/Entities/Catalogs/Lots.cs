using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class Lots : BaseEntity<Guid>
{
    public Guid SectionId { get; set; }
    public virtual Sections Section { get; set; } = null!;

    public string Code { get; set; } = null!;

    public decimal WidthMetres { get; set; }
    public decimal LengthMetres { get; set; }

    public int NominalRows { get; set; }
    public int NominalColumns { get; set; }
    public decimal PositionX { get; set; }
    public decimal PositionY { get; set; }
    public decimal PositionZ { get; set; }
    public decimal RotationY { get; set; }

    public bool AllowsStacking { get; set; } = true!;

    public RackStatus Status { get; set; }
    public string? UnavailableReason { get; set; }
    public DateTime? StatusChangedAt { get; set; }

    public virtual ICollection<LotsPositions> Positions { get; set; } = [];
    public virtual ICollection<WarehouseAssignments> Assignments { get; set; } = [];
    public virtual ICollection<Stocks> CurrentStock { get; set; } = [];
}