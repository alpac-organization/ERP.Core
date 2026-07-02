using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class WarehouseReceiptsManagua : BaseEntity<Guid>
{
    public Guid RecordEntranceManaguaId { get; set; }
    public string ReceiptNumber { get; set; } = null!;
    public string ResaNumber { get; set; } = null!;
    public decimal CustomsCIFValue { get; set; }
    public string CustomsBrokerage { get; set; } = null!;
    public DateTime ReceiptCreationDate { get; set; }
    public DateTime? ReceiptCancellationDate { get; set; }

    // Propiedades de navegación
    public virtual RecordEntranceManagua RecordEntranceManagua { get; set; } = null!;
}