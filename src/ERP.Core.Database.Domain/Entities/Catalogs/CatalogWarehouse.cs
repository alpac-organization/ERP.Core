using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class CatalogWarehouse : BaseEntity<Guid>
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
    public virtual CatalogWarehouse? Parent {get; set;}
    public virtual ICollection<CatalogWarehouse> Children {get; set;} = [];
}