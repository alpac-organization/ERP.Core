using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Operations;
using ERP.Core.Database.Domain.Entities.Warehouse;

using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class SupplyRequest : BaseEntity<Guid>
    {
        public string? Code { get; set; }
        public string? Justification { get; set; }
        public OutflowStatus OutflowStatus { get; set; }
        

        //Area solicitante
        public Guid WorkAreaId { get; set; }
        public virtual WorkArea WorkArea { get; set; } = default!;

        //Centro de costo
        public Guid CostCenterId { get; set; }
        public virtual CostCenter CostCenter { get; set; } = default!;

        //Bodega destino.
        public Guid WarehouseId { get; set; }
        public virtual Warehouses Warehouse { get; set; } = default!;

        //Que operación piensa atender
        public Guid OperationalOrderId { get; set; }
        public virtual OperationalOrder OperationalOrder { get; set; } = default!;

        //Solicitado por 
        public Guid RequestedByUserId { get; set; }
        public virtual User User { get; set; } = default!;


        //Stock Solicitado en la solicitud.
        public virtual ICollection<SupplyRequestItem> SupplyRequestItems { get; set; } = [];
    }
}