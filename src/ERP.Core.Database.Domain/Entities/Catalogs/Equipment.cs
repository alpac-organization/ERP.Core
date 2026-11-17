using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Inventory;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class Equipment : BaseEntity<Guid>
{
    public Guid BranchId { get; set; }

    public string Brand { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string Year { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string SerialNumber { get; set; } = null!;
    public string? Color { get; set; }

    public EquipmentStatus Status { get; set; }
    public EquipmentType Type { get; set; }
    public bool IsActive { get; set; } = true;

    public bool Gasoline { get; set; }
    public bool Diesel { get; set; }
    public bool Electric { get; set; }
    public bool Lpg { get; set; }

    public virtual Branch Branch { get; set; } = default!;
    public virtual ICollection<FuelRequest> FuelRequests { get; set; } = [];
}   