using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class MachineryAssignments : BaseEntity<Guid>
{
    public Guid WarehouseAssignmentId { get; set; }
    public Guid? MachineryId { get; set; }
    public Guid? OperatorCollaboratorId { get; set; } 
    public bool IsOutsourced { get; set; }
    public string? ProviderName { get; set; }
    public string? InvoiceNumber { get; set; }
    public string? MachineryDescription { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public Guid AssignedByUserId { get; set; }

    public virtual WarehouseAssignments WarehouseAssignment { get; set; } = null!;
    public virtual WarehouseMachinery? Machinery { get; set; }
}
