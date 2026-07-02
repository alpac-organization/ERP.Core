using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class DucatRegistryDetailsManagua : BaseEntity<Guid>
{
    public Guid RecordEntranceManaguaId { get; set; }
    public Guid EntranceDucatManaguaId { get; set; }
    public Guid CategoryProductId { get; set; }
    public int TotalBultos { get; set; }
    public decimal TotalWeight { get; set; }
    public string ProductDescription { get; set; } = null!;
    public string Remitente { get; set; } = null!;
    public string DestinationAreaObservation { get; set; } = null!;
    public virtual DucatRegistryManagua DucatRegistry { get; set; } = null!;
    public virtual EntranceDucatsManagua EntranceDucat { get; set; } = null!;
    public virtual CategoryProducts CategoryProduct { get; set; } = null!;
}