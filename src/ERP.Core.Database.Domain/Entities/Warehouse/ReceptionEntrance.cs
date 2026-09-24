using System.Text.Json.Nodes;

using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Operations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Core.Database.Domain.Entities.Warehouse
{
    public class ReceptionEntrance : BaseEntity<Guid>
    {
        // informacion de OP
        public bool IsActive { get; set; }
        public string SealNumber { get; set; } = null!;  // marchamo | precinto
        public string ContainerNumber { get; set; } = null!;
        public string CountryOfOrigin { get; set; } = null!;

        public Guid CustomBranchId { get; set; }  //aduana
        public virtual CustomsBranches CustomsBranches { get; set; } = null!;

        public string? AdditionalData { get; set; }

        public virtual ReceptionTransportEntrance ReceptionTransport { get; set; } = default!;
        public virtual ICollection<OperationalOrder> OperationalOrders { get; set; } = [];
    }
    public class AdditionalReceptionEntranceData
    {
        public List<DocumentInformation> DocumentNumbers { get; set; } = [];
        public List<ImagesInformation> EvidenceUrls { get; set; } = [];
    }

    public class ImagesInformation
    {
        public Guid ImageId { get; set; }
        public string? ImageUrl { get; set; }
    }

    public class DocumentInformation
    {
        public Guid DocumentId { get; set; }
        public DocumentType DocumentType { get; set; }
        public string? DocumentNumbers { get; set; }
    }
}