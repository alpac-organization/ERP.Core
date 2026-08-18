using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class EntranceDucats : BaseEntity<Guid>
{
    public string DucatNumber { get; set; } = null!;
    public DucaStatus Status { get; set; }
    public Guid RecordEntranceId { get; set; }
    public virtual RecordEntrance RecordEntrance { get; set; } = null!;

    public virtual Discrepancies? Discrepancy { get; set; }
    public virtual DucatRegistryDetails? RegistryDetail { get; set; }

    public Guid? ServiceOrderId { get; set; }
    public string? ServiceOrderCode { get; set; }
    public virtual ServiceOrder? ServiceOrder { get; set; }

}