using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class UnloadingMachineryAssignments : BaseEntity<Guid>
{
    public Guid UnloadingDetailsId { get; set; }
    public Guid MachineryCode { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string AssignedByUserId { get; set; } = null!;

    // Propiedades de navegación
    public virtual UnloadingDetails UnloadingDetails { get; set; } = null!;
    public virtual WarehouseMachinery Machinery { get; set; } = null!;
}