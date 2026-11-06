using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class SupplyRequest : BaseSupplyRequest
    {
        // Bodega destino.
        public Guid WarehouseId { get; set; }
        public virtual Warehouses Warehouse { get; set; } = default!;

        //Que operación piensa atender
        public Guid OperationalOrderId { get; set; }
        public virtual OperationalOrder OperationalOrder { get; set; } = default!;

        //Stock Solicitado en la solicitud.
        public virtual ICollection<SupplyRequestItem> SupplyRequestItems { get; set; } = [];
        public virtual InventoryOutputs InventoryOutput { get; set; } = default!;
    }
}