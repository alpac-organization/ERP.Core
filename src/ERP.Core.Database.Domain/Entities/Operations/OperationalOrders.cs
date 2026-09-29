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
        public string? PoCode { get; set; }
        public string? Description { get; set; }
        public string? DocumentNumber { get; set; }
        public bool IsConsolidated { get; set; } = false;

        public decimal? Weight { get; set; }
        public decimal? PackagesCount { get; set; }

        public DocumentType DocumentType { get; set; }
        public OperationalOrderStatus Status { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = default!;

        public Guid CostCenterId { get; set; }
        public virtual CostCenter CostCenter { get; set; } = default!;

        public Guid? CustomerId { get; set; }
        public virtual Customers Customer { get; set; } = default!;

        public EmploymentType EmploymentType { get; set; }

        public string? AdditionalData { get; set; } = "{}";

        //reference with warehouse flow...
        public Guid ReceptionId { get; set; }
        public virtual ReceptionEntrance Reception { get; set; } = default!;

        //referencias a asignamiento
        public bool HasCollaboratorsAssigned { get; set; }
        public bool HasMachineryAssigned { get; set; }
        public bool HasEnclosureAssigned { get; set; }

        //Información de la factura

        //Servicios abjuntados a la orden operativa / navegaciones
        public virtual ICollection<ServicesOrder> ServicesOrders { get; set; } = [];
        public virtual ICollection<AssignmentsMachinery> AssignmentsMachineries { get; set; } = [];
        public virtual ICollection<AssignmentCollaborators> AssignmentCollaborators { get; set; } = [];
        public virtual ICollection<AssignmentEnclosure> AssignmentEnclosures { get; set; } = [];

    }
}