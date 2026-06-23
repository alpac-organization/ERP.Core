using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class Product : BaseEntity<Guid>
{
    public Guid CustomerId {get; set;}
    public Guid CategoryProductsId {get; set;}
    public string SKU {get; set;} = null!;
    public string Name {get; set;} = null!;
    public string Description {get; set;} = null!;
    public string UnitOfMeasure {get; set;} = null!;
    public bool IsActive {get; set;}

    /// <summary>
    /// Recursividad
    /// </summary>
    public Guid? CategoryId {get; set;}
    public virtual Product? Category {get; set;}

    /// <summary>
    /// Relaciones externas
    /// </summary>
    public virtual Customer Customer {get; set;} = default!;
    public virtual CategoryProducts CategoryProducts {get; set;} = default!;
}