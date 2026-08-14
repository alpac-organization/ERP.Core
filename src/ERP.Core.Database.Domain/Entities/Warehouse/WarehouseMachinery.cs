using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class WarehouseMachinery : BaseEntity<Guid>
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public MachineryType MachineryType { get; set; }
    public bool IsActive { get; set; } = true;

    // Propiedades de navegación
    public virtual ICollection<UnloadingMachineryAssignments> Assignments { get; set; } = [];
}