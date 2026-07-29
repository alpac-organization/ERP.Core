using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class RecordEntrance : BaseEntity<Guid>
{
    public Guid? ServiceOrderId { get; set; }
    public string CurrentStepCode { get; set; } = null!;
    public RecordEntranceStatus Status { get; set; }
    public DateOnly? ClosedAtDate { get; set; }
    public TimeOnly? ClosedAtTime { get; set; }

    public bool IsConsolidated { get; set; } = false;


    //Navegaciones
    public virtual WorkflowStepDefinition CurrentStep { get; set; } = null!;
    public virtual ReceptionEntrance? ReceptionEntrance { get; set; }
    public virtual DucatRegistry? DucatRegistry { get; set; }

    public virtual WarehouseAssignments? Assignment { get; set; }
    public virtual UnloadingDetails? UnloadingDetails { get; set; }
    public virtual ManifestCancellations? ManifestCancellation { get; set; }
    public virtual WarehouseReceipts? WarehouseReceipt { get; set; }
    public virtual CustomsDeclarations? CustomsDeclarations { get; set; }

    public virtual ICollection<EntranceDucats> EntranceDucats { get; set; } = [];
    public virtual ICollection<Discrepancies> Discrepancies { get; set; } = [];
    public virtual ICollection<StepExecutionLogs> ExecutionLogs { get; set; } = [];
}