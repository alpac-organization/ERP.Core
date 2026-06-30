using System.ComponentModel.DataAnnotations;
using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse_MNG;

namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class StocksManagua
{
    public Guid Id { get; set; }
    public Guid RackId { get; set; }
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
    public DateTime StoredAt { get; set; }
    
    [Timestamp]
    public byte[] RowVersion { get; set; } = null!;

    // Propiedades de navegación
    public virtual RacksManagua Rack { get; set; } = null!;
    public virtual Products Product { get; set; } = null!;
}