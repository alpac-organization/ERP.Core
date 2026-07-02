using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class DiscrepanciesManagua : BaseEntity<Guid>
{
    public Guid RecordEntranceManaguaId { get; set; }
    public Guid EntranceDucatsManaguaId { get; set; }
    public string DiscrepancyType { get; set; } = null!; // SOBRANTE, FALTANTE, MERCANCIA_DIFERENTE
    public decimal DeclaredQuantity { get; set; }
    public decimal FoundQuantity { get; set; }
    public string? CustomsLetterReference { get; set; }
    public string Description { get; set; } = null!;
    public bool IsDamage { get; set; } = false;

    // Propiedades de navegación
    public virtual RecordEntranceManagua RecordEntranceManagua { get; set; } = null!;
    public virtual EntranceDucatsManagua EntranceDucat { get; set; } = null!;
}