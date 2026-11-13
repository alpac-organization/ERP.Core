using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Inventory;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class CategoryProducts : BaseEntity<Guid>
{
    public string? Name {get; set;}
    public string? Code {get; set;}
    public bool IsActive {get; set;} = true;
    public bool IsService { get; set; } = false;
    public bool IsFuel { get; set; } = false;
    public CategoryType CategoryType { get; set; }

    public Guid? ParentId { get; set; }
    public virtual CategoryProducts? Parent { get; set; }
    
    public virtual ICollection<Product> Products { get; set; } = [];
    public virtual ICollection<CategoryProducts> Children { get; set; } = [];
    // public virtual ICollection<InventoryAllowedCategories> InventoryAllowedCategories { get; set; } = [];
    public virtual ICollection<CategoryAllowedUnitMeasures> CategoryAllowedUnitMeasures { get; set; } = [];
}