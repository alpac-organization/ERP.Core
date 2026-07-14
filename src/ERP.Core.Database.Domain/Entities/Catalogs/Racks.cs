using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class Racks : BaseEntity<Guid>
{
    public Guid SectionId { get; set; }
    public string Code { get; set; } = null!;
    public int RowNumber { get; set; }
    public int LevelNumber { get; set; }
    public decimal CostPerPosition { get; set; }
    public bool IsAvailable { get; set; } = true;
    public decimal MaxWeightKg {get;set;}
    public decimal MaxHeightMetres {get;set;}

    // Propiedad de navegación hacia el padre (Zona)
    public virtual Sections Section { get; set; } = null!;
    public virtual ICollection<WarehouseAssignments> Assignments { get; set; } = [];
    public virtual ICollection<Stocks> CurrentStock { get; set; } = [];
}