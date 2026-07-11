using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class UnloadingCrewAssignmentsManagua : BaseEntity<Guid>
{
    public DateTime AssignedAt { get; set; }
    public int PersonaCount { get; set; }
    public bool Tecerizada { get; set; }

    public Guid UnloadingDetailsManaguaId { get; set; }
    public virtual UnloadingDetailsManagua UnloadingDetails { get; set; } = null!;
}