using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
public class LayoutTransform : BaseEntity<Guid>
{
    public decimal PositionX { get; set; }
    public decimal PositionY { get; set; }
    public decimal PositionZ { get; set; }
    public decimal RotationY { get; set; }

    public Guid? SectionId { get; set; }
    public virtual Sections? Sections { get; set; }

    public Guid? RackId { get; set; }
    public virtual Racks? Rack { get; set; }
    public Guid? LotId { get; set; }
    public virtual Lots? Lot { get; set; }
}