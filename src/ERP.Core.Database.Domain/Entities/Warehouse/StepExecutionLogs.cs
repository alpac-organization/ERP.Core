using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class StepExecutionLogs : BaseEntity<Guid>
{
    public Guid RecordEntranceId { get; set; }
    public string WorkflowStepDefinitionCode { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public DateOnly? EndDate { get; set; }
    public TimeOnly? EndTime { get; set; }
    public string ProcessedByUserId { get; set; } = null!;
    public string ProcessedByUserName { get; set; } = null!;
    
    public string? FinishedByUserId { get; set; } = null!;
    public string? FinishedByUserName { get; set; } = null!;
    

    // Propiedades de navegación
    public virtual RecordEntrance RecordEntrance { get; set; } = null!;
    public virtual WorkflowStepDefinition WorkflowStepDefinition { get; set; } = null!;
}