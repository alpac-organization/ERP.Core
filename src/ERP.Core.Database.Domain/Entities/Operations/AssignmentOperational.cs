using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Operations
{
    public class AssignmentOperational : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public Guid OperationalOrderId { get; set; }
        public virtual OperationalOrder OperationalOrder { get; set; } = default!;

        // informacion de mercaderia
        public string? Observations { get; set; }
        public string? Merchandise { get; set; } = null!;
        public string? MerchandiseDescription { get; set; } = null!;
        public bool HasMerchandiseDescription { get; set; } = false;
        public MerchandiseCategory? Category { get; set; }

        public DestinationType DestinationType { get; set; }
        public AssignmentOperationalStatus Status { get; set; }

        public Guid? WarehouseId { get; set; }
        public virtual Warehouses Warehouse { get; set; } = default!;

        public bool HasMachineryAssigned { get; set; }
        public bool HasEnclosureAssigned { get; set; }
        public bool HasCollaboratorsAssigned { get; set; }

        //1:M
        public virtual ICollection<AssignmentsMachinery> AssignmentsMachineries { get; set; } = [];
        public virtual ICollection<AssignmentCollaborators> AssignmentCollaborators { get; set; } = [];

        public string? AdditionalData { get; set; } = "{}";
    }

    public class AdditionalDataAssingmentOperational
    {
        //En espera..   
    }
}