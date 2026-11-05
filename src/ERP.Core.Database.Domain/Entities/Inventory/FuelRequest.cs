using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Inventory;

public class FuelRequest : BaseSupplyRequest
{
    public Guid MachineryId { get; set; }
    public virtual Machinery Machinery { get; set; } = default!;

    // tipo de combustible
    public Guid ProductStockId { get; set; }
    public virtual ProductStock ProductStock { get; set; } = default!;

    // unidad de medida, predeterminada en Galones
    public Guid UnitMeasureId { get; set; }
    public virtual UnitMeasure UnitMeasure { get; set; } = default!;

    public decimal RequestedQuantity { get; set; }
    public decimal? Mileage { get; set; }                           // kilometraje del vehiculo particular
    public decimal? EngineHours { get; set; }                       // horas motor para maquinaria

    public virtual InventoryOutputs InventoryOutput { get; set; } = default!;
}