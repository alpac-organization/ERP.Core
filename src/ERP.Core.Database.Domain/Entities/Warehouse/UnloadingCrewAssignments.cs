using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class UnloadingCrewAssignments : BaseEntity<Guid>
{
    public DateTime AssignedAt { get; set; }
    public int PersonaCount { get; set; }
    public bool Tecerizada { get; set; }

    public Guid UnloadingDetailsId { get; set; }
    public virtual UnloadingDetails UnloadingDetails { get; set; } = null!;
}