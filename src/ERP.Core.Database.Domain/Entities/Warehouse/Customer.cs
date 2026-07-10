using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class Customer : BaseEntity<Guid>
{
    public string? DNI_RUC {get; set;}
    public string? LegalName {get; set;}
    public bool IsActive {get; set;} = true;
    public string? PictureUrl { get; set; }

    public Guid CustomerTypeId {get; set;}
    public virtual CustomerType CustomerType {get; set;} = default!;

    public virtual ICollection<Products> Products { get; set; } = [];
    public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = [];
}