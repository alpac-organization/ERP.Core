using System.ComponentModel.DataAnnotations;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class StocksManagua : BaseEntity<Guid>
{
    public Guid WarehouseId { get; set; }
    public Guid EntranceDucatsManaguaId { get; set; }
    public Guid ZonesManaguaId { get; set; }
    public Guid RacksManaguaId { get; set; }
    public Guid CategoryProductId { get; set; }
    public int CurrentBultos { get; set; }
    public decimal CurrentWeightKg { get; set; }
    public DateTime StoredAt { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; } = null!;

    // Propiedades de navegación
    public virtual EntranceDucatsManagua EntranceDucat { get; set; } = null!;
    public virtual RacksManagua Rack { get; set; } = null!;
    public virtual CategoryProducts Product { get; set; } = null!;
    public virtual ZonesManagua Zone { get; set; } = null!;
}