using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class SectionDetails : BaseEntity<Guid>
{
    public Guid SectionId { get; set; }

    public decimal WidthMetres { get; set; }
    public decimal LengthMetres { get; set; }
    public decimal HeigthMetres { get; set; }

    public virtual Sections Section { get; set; } = null!;
}