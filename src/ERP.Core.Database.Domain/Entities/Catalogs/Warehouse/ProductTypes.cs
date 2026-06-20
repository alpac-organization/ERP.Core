using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs.Warehouse;

public class ProductsTypes : BaseEntity<Guid>
{
    public string Name {get; set;} = null!;
}