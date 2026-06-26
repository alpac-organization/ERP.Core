namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class ManifestCancellationsManagua
{
    // Relación 1:1 - Llave primaria y foránea al mismo tiempo
    public Guid RecordEntranceManaguaId { get; set; }
    public string ManifestNumber { get; set; } = null!;
    public int ContainerCount { get; set; }
    public string ContainerDimension { get; set; } = null!; // Ej: 20 pies, 40 pies
    public string PersonnelType { get; set; } = null!; // PROPIO_EMPRESA o DEL_CLIENTE
    public string CustomsOfficerSignature { get; set; } = null!;
    public string WarehouseChiefSignature { get; set; } = null!;

    // Propiedades de navegación
    public virtual RecordEntranceManagua RecordEntranceManagua { get; set; } = null!;
}