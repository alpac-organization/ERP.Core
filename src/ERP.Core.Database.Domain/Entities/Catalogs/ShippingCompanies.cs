using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class ShippingCompanies : BaseEntity<Guid>
{
    public string Name { get; set; } = null!;

    public virtual ICollection<DucatRegistry> DucatRegistries { get; set; } = [];
}