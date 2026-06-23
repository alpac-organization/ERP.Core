using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class Product : BaseEntity<Guid>
{
    public string? SKU {get; set;}
    public string? Name {get; set;}
    public string? Description {get; set;}
    public string? UnitOfMeasure {get; set;}
    public bool IsActive {get; set;}

    public Guid CategoryId {get; set;}
    public virtual CategoryProducts Category {get; set;} = default!;

    public Guid CustomerId {get; set;}
    public virtual Customer Customer {get; set;} = default!;
}