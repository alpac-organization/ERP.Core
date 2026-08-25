using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class ReassignmentSessionOwnershipLog : BaseEntity<Guid>
{
    public Guid ReassignmentSessionId { get; set; }
    public virtual ReassignmentSessions Session { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public DateOnly StartedAtDate { get; set; }
    public TimeOnly StartedAtTime { get; set; }
    public DateOnly? EndedAtDate { get; set; }
    public TimeOnly? EndedAtTime { get; set; }
}