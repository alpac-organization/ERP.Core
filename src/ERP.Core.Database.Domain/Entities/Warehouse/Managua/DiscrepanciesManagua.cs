using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class DiscrepanciesManagua
{
    public Guid Id { get; set; }
    public Guid RecordEntranceManaguaId { get; set; }
    public Guid ProductId { get; set; }
    public string DiscrepancyType { get; set; } = null!; // SOBRANTE, FALTANTE, MERCANCIA_DIFERENTE
    public decimal DeclaredQuantity { get; set; }
    public decimal FoundQuantity { get; set; }
    public string? CustomsLetterReference { get; set; }
    public string Description { get; set; } = null!;

    // Propiedades de navegación
    public virtual RecordEntranceManagua RecordEntranceManagua { get; set; } = null!;
    public virtual Products Product { get; set; } = null!;
}