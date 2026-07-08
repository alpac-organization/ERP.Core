using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;

namespace ERP.Core.Database.Domain.Entities.Catalogs.Warehouse_MNG;

public class WorkflowStepDefinition : BaseEntity<int>
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int ExecutionOrder { get; set; }

    // Propiedad inversa para la navegación
    public virtual ICollection<RecordEntranceManagua> RecordEntrances { get; set; } = [];
}