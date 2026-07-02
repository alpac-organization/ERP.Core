using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class UnloadingMachineryAssignmentsManagua : BaseEntity<Guid>
{
    public Guid UnloadingDetailsManaguaId { get; set; }
    public Guid MachineryCode { get; set; }
    public Guid MachineryType { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string AssignedByUserId { get; set; } = null!;

    // Propiedades de navegación
    public virtual UnloadingDetailsManagua UnloadingDetailsManagua { get; set; } = null!;
}