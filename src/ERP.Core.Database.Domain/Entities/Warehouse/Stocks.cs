using System.ComponentModel.DataAnnotations;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class Stocks : BaseEntity<Guid>
{
    public Guid WarehouseId { get; set; }
    public Guid EntranceDucatsId { get; set; }
    public Guid SectionId { get; set; }
    public Guid RacksId { get; set; }
    public Guid CategoryProductId { get; set; }
    public int CurrentBultos { get; set; }
    public decimal CurrentWeightKg { get; set; }
    public DateTime StoredAt { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; } = null!;

    // Propiedades de navegación
    public virtual EntranceDucats EntranceDucat { get; set; } = null!;
    public virtual Racks Rack { get; set; } = null!;
    public virtual CategoryProducts Product { get; set; } = null!;
    public virtual Sections Section { get; set; } = null!;
}