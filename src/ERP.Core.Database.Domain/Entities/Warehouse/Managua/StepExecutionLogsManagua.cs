using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse_MNG;

namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class StepExecutionLogsManagua : BaseEntity<Guid>
{
    public Guid RecordEntranceManaguaId { get; set; }
    public int WorkflowStepDefinitionId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string ProcessedByUserId { get; set; } = null!;

    // Propiedades de navegación
    public virtual RecordEntranceManagua RecordEntranceManagua { get; set; } = null!;
    public virtual WorkflowStepDefinition WorkflowStepDefinition { get; set; } = null!;
}