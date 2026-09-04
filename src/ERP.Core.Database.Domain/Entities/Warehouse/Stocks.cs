using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class Stocks : BaseEntity<Guid>
{
    public Guid WarehouseId { get; set; }
    public Guid EntranceDucatsId { get; set; }
    public Guid MerchandiseId { get; set; }
    public Guid CategoryProductId { get; set; }
    public int CurrentBultos { get; set; }
    public decimal CurrentWeightKg { get; set; }
    public DateTime StoredAt { get; set; }

    public uint RowVersion { get; set; }

    // Propiedades de navegación
    public virtual EntranceDucats EntranceDucat { get; set; } = null!;
    public virtual CategoryProducts Product { get; set; } = null!;
    public virtual Merchandises Merchandise { get; set; } = null!;
}