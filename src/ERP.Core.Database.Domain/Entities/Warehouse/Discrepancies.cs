using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class Discrepancies : BaseEntity<Guid>
{
    public string DiscrepancyType { get; set; } = null!; // SOBRANTE, FALTANTE, MERCANCIA_DIFERENTE
    public decimal DeclaredQuantity { get; set; }
    public decimal FoundQuantity { get; set; }
    public string? CustomsLetterReference { get; set; }
    public string Description { get; set; } = null!;
    public bool IsDamage { get; set; } = false;

    // Propiedades de navegación
    public Guid RecordEntranceId { get; set; }

    public Guid EntranceDucatsId { get; set; }
}