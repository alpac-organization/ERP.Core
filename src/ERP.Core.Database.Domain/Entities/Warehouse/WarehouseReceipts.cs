using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class WarehouseReceipts : BaseEntity<Guid>
{
    public Guid RecordEntranceId { get; set; }
    public string ReceiptNumber { get; set; } = null!;
    public string ResaNumber { get; set; } = null!;
    public decimal CustomsCIFValue { get; set; }
    public string CustomsBrokerage { get; set; } = null!;
    public DateTime ReceiptCreationDate { get; set; }
    public DateTime? ReceiptCancellationDate { get; set; }

    // Propiedades de navegación
    public virtual RecordEntrance RecordEntrance { get; set; } = null!;
}