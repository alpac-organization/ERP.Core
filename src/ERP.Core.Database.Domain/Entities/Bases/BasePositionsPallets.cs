using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Bases;

public abstract class BasePositionsPallets : BaseEntity<Guid>
{
    public string PositionCode { get; set; } = null!;
    public int Row { get; set; }
    public int Column { get; set; }
    public int Level { get; set; }
    public RackStatus Status { get; set; } = RackStatus.Available;
    public bool AllowsStocking { get; set; }
    public string? Observations { get; set; }
}