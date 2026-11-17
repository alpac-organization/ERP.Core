using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class SupplyRequest : BaseSupplyRequest
    {

        //Que operación piensa atender
        public Guid? OperationalOrderId { get; set; }
        public virtual OperationalOrder OperationalOrder { get; set; } = default!;

        //Stock Solicitado en la solicitud.
        public virtual ICollection<SupplyRequestItem> SupplyRequestItems { get; set; } = [];
        public virtual InventoryOutputs InventoryOutput { get; set; } = default!;


        //Campos temporales mientras se amarra modulos
        public Guid? EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; } = default!;
        public Guid? CustomerId { get; set; }
        public virtual Customers Customer { get; set; } = default!;
        public string? DucaOrTransportOrder { get; set; }
    }
}