using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class WarehouseMachinery : BaseEntity<Guid>
{
    public Guid CompanyId { get; set; }
    public Guid BranchId { get; set; }
    public Guid WarehouseId { get; set; }
    public Guid? AssignedOperatorId { get; set; }

    public string Code { get; set; } = null!;
    public string SerialNumber { get; set; } = null!;
    public string? LicensePlate { get; set; }
    public string Name { get; set; } = null!;
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!;
    public int ManufactureYear { get; set; }
    public string? ImageUrl { get; set; }

    public MachineryType MachineryType { get; set; }
    public FuelType FuelType { get; set; }
    public decimal LoadCapacityKg { get; set; }
    public decimal? MaxReachHeightMeters { get; set; }
    public decimal HourMeter { get; set; }

    public MachineryStatus Status { get; set; }
    public DateTime? LastMaintenanceDate { get; set; }
    public DateTime? NextMaintenanceDate { get; set; }
    public string? Notes { get; set; }

    public DateTime? PurchaseDate { get; set; }
    public DateTime? WarrantyExpirationDate { get; set; }

    public bool IsActive { get; set; } = true;

    // Propiedades de navegación
    public virtual ICollection<MachineryAssignments> Assignments { get; set; } = [];
}