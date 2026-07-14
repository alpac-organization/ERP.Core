
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class ManifestCancellations : BaseEntity<Guid>
{
    public Guid ServiceOrdersId { get; set; }
    public Guid RecordEntranceId { get; set; }
    public string ManifestNumber { get; set; } = null!;
    public int ContainerCount { get; set; }
    public string ContainerDimension { get; set; } = null!; // Ej: 20 pies, 40 pies
    public string PersonalType { get; set; } = null!; // PROPIO_EMPRESA o DEL_CLIENTE
    public string CustomsOfficerSignature { get; set; } = null!;
    public string WarehouseChiefSignature { get; set; } = null!;

    // Propiedades de navegación
    public virtual RecordEntrance RecordEntrance { get; set; } = null!;
    public virtual ServiceOrder ServiceOrder { get; set; } = null!;
}