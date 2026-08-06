using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class Merchandises : BaseEntity<Guid>
{
    public string MerchandiseName { get; set; } = null!;
    public string? Description { get; set; }

    public Guid CategoryId {get; set;}
    public virtual CategoryProducts Category {get; set;} = default!;

    public virtual ICollection<DucatRegistryDetails> DucatRegistryDetails {get;set;} = [];

}