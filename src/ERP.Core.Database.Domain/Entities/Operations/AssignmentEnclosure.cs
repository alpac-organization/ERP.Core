using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Operations;

public class AssignmentEnclosure : BaseEntity<Guid>
{
    public Guid? WarehouseId { get; set; }
    public virtual Warehouses Warehouse { get; set; } = default!;
    public DestinationType DestinationType { get; set; }
    public string? Observations { get; set; }
    public string Merchandise { get; set; } = null!;
    public string MerchandiseDescription { get; set; } = null!;
}