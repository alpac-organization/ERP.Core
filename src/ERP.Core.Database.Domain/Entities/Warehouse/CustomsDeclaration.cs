using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class CustomsDeclarations : BaseEntity<Guid>
{
    public string CustomsDeclarationNumber { get; set; } = null!;
    public Guid RecordEntranceId { get; set; }
    public virtual RecordEntrance RecordEntrance { get; set; } = null!;

    public virtual CustomsDeclarationDetails? Details { get; set; }

    public Guid? ServiceOrderId { get; set; }
    public string? ServiceOrderCode { get; set; }
    public DucaStatus Status { get; set; }

    public virtual ServiceOrder? ServiceOrder { get; set; }

}