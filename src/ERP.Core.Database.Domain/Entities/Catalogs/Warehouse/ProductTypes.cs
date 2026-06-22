using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs.Warehouse;

public class ProductType : BaseEntity<Guid>
{
    public string Name {get; set;} = null!;
    public bool IsActive {get; set;} = true;

}