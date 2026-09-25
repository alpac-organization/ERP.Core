using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class Machinery : BaseEntity<Guid>
{
    public Guid BranchId { get; set; }

    public string Brand { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string Year { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string SerialNumber { get; set; } = null!;

    public MachineryStatus Status { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual Branch Branch { get; set; } = default!;
}