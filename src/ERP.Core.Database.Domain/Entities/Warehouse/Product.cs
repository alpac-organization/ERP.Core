using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class Product : BaseEntity<Guid>
{
    public string? ProductName { get; set; }
    public string? Description { get; set; }

    public Guid CategoryId {get; set;}
    public virtual CategoryProducts Category {get; set;} = default!;
    
    public virtual ICollection<PurchaseRequestItem> PurchaseRequestItems { get; set; } = [];
}