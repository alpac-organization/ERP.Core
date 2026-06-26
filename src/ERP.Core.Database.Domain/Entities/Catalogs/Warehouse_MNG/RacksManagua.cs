using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs.Warehouse_MNG;

public class RacksManagua : BaseEntity<Guid>
{
    public Guid ZoneId { get; set; }
    public string Code { get; set; } = null!;
    public int RowNumber { get; set; }
    public int LevelNumber { get; set; }
    public decimal CostPerPosition { get; set; }
    public bool IsOccupied { get; set; } = false;

    // Propiedad de navegación hacia el padre (Zona)
    public virtual ZonesManagua Zone { get; set; } = null!;
}