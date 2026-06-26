using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse_MNG;

namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class StepExecutionLogsManagua
{
    public Guid Id { get; set; }
    public Guid RecordEntranceManaguaId { get; set; }
    public int WorkflowStepDefinitionId { get; set; }
    public string UserId { get; set; } = null!;
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    // Propiedades de navegación
    public virtual RecordEntranceManagua RecordEntranceManagua { get; set; } = null!;
    public virtual WorkflowStepDefinition WorkflowStepDefinition { get; set; } = null!;
}