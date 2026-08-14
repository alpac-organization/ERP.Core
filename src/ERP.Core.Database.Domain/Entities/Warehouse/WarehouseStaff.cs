using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class WarehouseStaff : BaseEntity<Guid>
{
    public string FullName { get; set; } = null!;
    public string? Role { get; set; }
    public bool IsActive { get; set; } = true;
}