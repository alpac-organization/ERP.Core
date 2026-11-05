using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Bases;

public abstract class BaseSupplyRequest : BaseEntity<Guid>
{
    public string? Code { get; set; }
    public string? Justification { get; set; }
    public OutflowStatus OutflowStatus { get; set; }

    // area solicitante
    public Guid WorkAreaId { get; set; }
    public virtual WorkArea WorkArea { get; set; } = default!;

    public Guid CostCenterId { get; set; }
    public virtual CostCenter CostCenter { get; set; } = default!;

    public Guid BranchId { get; set; }
    public virtual Branch Branch { get; set; } = default!;

    public Guid RequestedByUserId { get; set; }
    public virtual User User { get; set; } = default!;

    public Guid? ApprovedByUserChiefId { get; set; }
    public Guid? AnnulledByUserChiefId { get; set; }
}