using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Operations;

public class Codes : BaseEntity<Guid>
{
    public Guid AssignmentId { get; set; }
    public virtual AssignmentOperational Assignment { get; set; } = default!;

    public CodesType CodeType { get; set; }
    public string ImageUrl { get; set; } = default!;
    public string CodeGenerated { get; set; } = default!;
}