using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class SectionOverflowCapacity : BaseEntity<Guid>
{
    public Guid SectionId { get; set; }

    public bool AllowsOverflowStorage { get; set; } = false;
    public bool IsOverflowEnabled { get; set; } = false;
    public int? MaxOverflowPolines { get; set; }

    public string? EnabledByUserName { get; set; }
    public DateOnly? EnabledDate { get; set; }
    public TimeOnly? EnabledTime { get; set; }

    public virtual Sections Section { get; set; } = null!;
}