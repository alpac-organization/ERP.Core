using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class CustomsDeclarations : BaseEntity<Guid>
{
    public string CustomsDeclarationNumber { get; set; } = null!;
    public Guid RecordEntranceId { get; set; }
    public virtual RecordEntrance RecordEntrance { get; set; } = null!;

    public virtual CustomsDeclarationDetails? Details { get; set; }
}