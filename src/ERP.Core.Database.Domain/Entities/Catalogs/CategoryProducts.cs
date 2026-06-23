using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class CategoryProducts : BaseEntity<Guid>
{
    public string Name {get; set;} = null!;
    public string? Code {get; set;}
    public bool IsActive {get; set;} = true;

    /// <summary>
    /// recursividad
    /// </summary>
    public Guid? CategoryId {get; set;}
    public virtual CategoryProducts? Category {get; set;}
    public virtual ICollection<CategoryProducts> SubCategory {get; set;} = [];
}