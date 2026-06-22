using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class Warehouses : BaseEntity<Guid>
{
    public Guid BranchId {get; set;}
    public string Code {get; set;} = null!;
    public string Name {get; set;} = null!;
    public Guid? AllowedCustomerTypeId {get; set;}
    public decimal TotalCubicCapacity {get; set;}
    public decimal TotalWeightCapacity {get; set;}
    public bool IsActive {get; set;} = true;


    public virtual Branch Branch {get; set;} = default!;
    public virtual CustomerType? CustomerType {get; set;}
}