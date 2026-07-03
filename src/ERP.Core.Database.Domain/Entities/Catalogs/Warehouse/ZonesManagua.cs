using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;

namespace ERP.Core.Database.Domain.Entities.Catalogs.Warehouse;

public class ZonesManagua : BaseEntity<Guid>
{
    public Guid WarehouseId { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;

    //Atributos de espacio y dimensiones
    public decimal WidthMetres { get; set; }
    public decimal LengthMetres { get; set; }
    public decimal HeightMetres { get; set; }
    public decimal TotalVolumeCapacityM3 { get; set; } // Capacidad volumétrica total en metros cúbicos
    public decimal MaxWeightCapacityKg { get; set; } // Capacidad de carga máxima en Kilogramos para la zona a piso

    public bool IsActive { get; set; } = true;

    public virtual Warehouses Warehouses { get; set; } = null!;
    public virtual ICollection<RacksManagua> Racks { get; set; } = [];
    public virtual ICollection<WarehouseAssignmentsManagua> Assignments { get; set; } = [];
    public virtual ICollection<StocksManagua> CurrentStock { get; set; } = [];
}