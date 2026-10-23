using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Clients;

/// <summary>
/// Infomrmacion tarifaria de cliente
/// </summary>
/// 
public class CustomerCharges : BaseEntity<Guid>
{
    public Guid CustomerId { get; set; }
    public Guid BranchId { get; set; }

    //  revisar estos 3 campos
    public string? ServiceDescription { get; set; }
    public string? Format { get; set; }                                 // presentacion de producto, ej: granel, sacos 50kg
    public string? Area { get; set; }                              // ej: Almacen

    public Guid MeasureUnitId { get; set; }
    public decimal Quantity { get; set; }
    public decimal USDFeeAmount { get; set; }                           // monto de la tarifa
    public decimal NIOFeeAmount { get; set; }                           // Conversion de moneda

    // navegaciones
    public virtual Customers Customer { get; set; } = default!;
    public virtual Branch Branch { get; set; } = default!;
    public virtual UnitMeasure UnitMeasure { get; set; } = default!;
}