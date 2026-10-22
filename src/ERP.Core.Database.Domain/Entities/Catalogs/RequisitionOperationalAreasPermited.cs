using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class RequisitionOperationalAreasPermited : BaseEntity<Guid>
{
    public Guid AreaId { get; set; }
    public Guid CompanyId { get; set; }
    public bool IsActive { get; set; }
    public Guid SetByUserId { get; set; }
    public ProductUsageType TypePermited { get; set; }
    public string? AreaName { get; set; }
    public string? CompanyName { get; set; }
    public string? SetByUserName { get; set; }


    // referencias || navegacones
    public virtual WorkArea Area { get; set; } = default!;
    public virtual Company Company { get; set; } = default!;
    public virtual User User { get; set; } = default!;
}