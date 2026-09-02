using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class Supplies : BaseEntity<Guid>
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual ICollection<UnloadingSupplies> UnloadingSupplies { get; set; } = [];
}