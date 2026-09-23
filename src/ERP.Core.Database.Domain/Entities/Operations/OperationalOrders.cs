using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Operations
{

    /// <summary>
    /// Englobador de ordenes de servicios por clientes
    /// </summary>
    public class OperationalOrder : BaseEntity<Guid>
    {
        public string? OpCode { get; set; }
        public string? Description { get; set; }
        public string? DocumentNumber { get; set; } // 1:1
        public int? PackagesCount { get; set; }
        public decimal? Weight { get; set; }

        // public OperationalOrderStatus Status { get; set; }

        public Guid CostCenterId { get; set; }
        public virtual CostCenter CostCenter { get; set; } = default!;

        public Guid? CustomerId { get; set; }
        public virtual Customers Customer { get; set; } = default!;


        //reference with warehouse...
        public Guid? ReceptionId { get; set; }
        public virtual ReceptionEntrance Reception { get; set; } = default!;

        //Información de la factura

        //Servicios abjuntados a la orden operativa
        public virtual ICollection<ServicesOrder> ServicesOrders { get; set; } = [];
    }
}