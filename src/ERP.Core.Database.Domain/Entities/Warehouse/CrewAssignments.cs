using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class CrewAssignments : BaseEntity<Guid>
{
    public DateTime AssignedAt { get; set; }
    public Guid? CollaboratorId { get; set; }
    public bool IsOutsourced { get; set; }
    public int? PersonCount { get; set; }
    public string? ProviderName { get; set; }
    public string? InvoiceNumber { get; set; }
    public Guid WarehouseAssignmentId { get; set; }

    public virtual WarehouseAssignments WarehouseAssignment { get; set; } = null!;
}
