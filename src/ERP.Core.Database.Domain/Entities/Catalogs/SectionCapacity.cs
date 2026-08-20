using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class SectionCapacity : BaseEntity<Guid>
{
    public Guid SectionId { get; set; }

    public decimal? UsableAreaM2 { get; set; }
    public decimal? UnusableAreaM2 { get; set; }

    public DateTime? LastCalculatedAt { get; set; }

    public virtual Sections Section { get; set; } = null!;
}