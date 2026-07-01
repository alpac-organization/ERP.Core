using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class CategoryProducts : BaseEntity<Guid>
{
    public string? Name {get; set;}
    public string? Code {get; set;}
    public bool IsActive {get; set;} = true;

    public Guid? ParentId { get; set; }
    public virtual CategoryProducts? Parent { get; set; }
    
    public virtual ICollection<Products> Products { get; set; } = [];
    public virtual ICollection<CategoryProducts> Children { get; set; } = [];
}