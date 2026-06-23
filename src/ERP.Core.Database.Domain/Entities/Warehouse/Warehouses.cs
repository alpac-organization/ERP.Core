using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class Warehouses : BaseEntity<Guid>
{
    public string Code {get; set;} = null!;
    public string Name {get; set;} = null!;
    public decimal TotalCubicCapacity {get; set;}
    public decimal TotalWeightCapacity {get; set;}
    public bool IsActive {get; set;} = true;
    public bool IsOwner {get; set;} = true;


    public Guid BranchId {get; set;}
    public virtual Branch Branch {get; set;} = default!;
}