using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse_MNG;

namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class RecordEntranceManagua : BaseEntity<Guid>
{
    public Guid ServiceOrderId { get; set; }
    public Guid WarehouseId { get; set; }
    public int CurrentStepId { get; set; }
    public WarehouseMgaStatus Status { get; set; }
    public DateTime? ClosedAt { get; set; }

    public bool IsConsolidated {get; set;} = false;


    //Navegaciones
    public virtual Warehouses Warehouse { get; set; } = null!;
    public virtual WorkflowStepDefinition CurrentStep { get; set; } = null!;
    public virtual ReceptionDetailsManagua? ReceptionDetails { get; set; }
    public virtual DucatRegistryManagua? DucatRegistry { get; set; }

    public virtual WarehouseAssignmentsManagua? Assignment { get; set; }
    public virtual UnloadingDetailsManagua? UnloadingDetails { get; set; }
    public virtual ManifestCancellationsManagua? ManifestCancellation { get; set; }
    public virtual WarehouseReceiptsManagua? WarehouseReceipt { get; set; }
   
    public virtual ICollection<EntranceDucatsManagua> EntranceDucats { get; set; } = [];
    public virtual ICollection<DiscrepanciesManagua> Discrepancies { get; set; } = [];
    public virtual ICollection<StepExecutionLogsManagua> ExecutionLogs { get; set; } = [];
}