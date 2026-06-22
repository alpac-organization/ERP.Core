using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class CategoryProducts : BaseEntity<Guid>
{
    /// <summary>
    /// Para tipos de Customer y Products
    /// </summary>
    public string Name {get; set;} = null!;
    public string? Code {get; set;}
    public bool IsActive {get; set;} = true;

    /// <summary>
    /// recursividad
    /// </summary>
    public Guid? ParentId {get; set;}
    public virtual CategoryProducts? Parent {get; set;}
    public virtual ICollection<CategoryProducts> Children {get; set;} = [];
}