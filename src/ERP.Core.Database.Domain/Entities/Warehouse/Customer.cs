using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class Customer : BaseEntity<Guid>
{
    public Guid CustomerTypeId {get; set;}
    public string DNI_RUC {get; set;} = null!;
    public string LegalName {get; set;} = null!;
    public bool IsActive {get; set;} = true;

    public virtual CustomerType CustomerType {get; set;} = default!;
}