using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class Tramos : BaseEntity<Guid>
{
    public Guid SectionId { get; set; }
    public virtual Sections Section { get; set; } = null!;
}