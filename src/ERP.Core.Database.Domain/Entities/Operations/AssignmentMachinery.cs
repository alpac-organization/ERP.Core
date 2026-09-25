using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Operations;

public class AssignmentsMachinery : BaseEntity<Guid>
{
    public Guid OperationalOrderId { get; set; }
    public virtual OperationalOrder OperationalOrder { get; set; } = default!;

    public Guid MachineryId { get; set; }
    public virtual Machinery Machinery { get; set; } = default!;

    public bool IsActive { get; set; } = true;
}
