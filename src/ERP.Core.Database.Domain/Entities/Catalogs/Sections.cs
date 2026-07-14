using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class Sections : BaseEntity<Guid>
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;

    //Atributos de espacio y dimensiones
    public decimal WidthMetres { get; set; }
    public decimal LengthMetres { get; set; }
    public decimal HeightMetres { get; set; }
    public decimal TotalVolumeCapacityM3 { get; set; } // Capacidad volumétrica total en metros cúbicos
    public decimal MaxWeightCapacityKg { get; set; } // Capacidad de carga máxima en Kilogramos para la zona a piso

    public bool IsActive { get; set; } = true;

    public Guid WarehouseId { get; set; }
    public virtual Warehouses Warehouses { get; set; } = null!;


    public virtual ICollection<Racks> Racks { get; set; } = [];
    public virtual ICollection<Stocks> CurrentStock { get; set; } = [];
    public virtual ICollection<WarehouseAssignments> Assignments { get; set; } = [];
}