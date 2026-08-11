using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class Sections : BaseEntity<Guid>
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public SectionType SectionType { get; set; }
    public bool IsActive { get; set; } = true;

    public decimal WidthMetres { get; set; }
    public decimal LengthMetres { get; set; }


    public Guid WarehouseId { get; set; }
    public virtual Warehouses Warehouse { get; set; } = null!;

    public virtual SectionOverflowCapacity? OverflowCapacity { get; set; }

    public virtual ICollection<Tramos> Tramos { get; set; } = [];
    public virtual ICollection<Stocks> CurrentStock { get; set; } = [];
    public virtual ICollection<WarehouseAssignments> Assignments { get; set; } = [];
}