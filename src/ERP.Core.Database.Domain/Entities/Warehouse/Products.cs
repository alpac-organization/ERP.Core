using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class Products : BaseEntity<Guid>
{
    public Guid CustomerId {get; set;}
    public int ProductType {get; set;}
    public string SKU {get; set;} = null!;
    public string Name {get; set;} = null!;
    public string Description {get; set;} = null!;
    public string UnitOfMeasure {get; set;} = null!;
    public bool IsActive {get; set;}

    public virtual Customer Customer {get; set;} = default!;
    public virtual ProductsTypes ProductsTypes {get; set;} = default!;
}