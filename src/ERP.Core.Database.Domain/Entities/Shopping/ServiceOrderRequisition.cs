using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class ServiceOrderRequistions : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }

        public string? Concept { get; set; }
        public string? SoRequitionCode { get; set; } //Número solicitud Generado.
        public ServiceOrderRequisitionStatus Status { get; set; }

        public Guid CreatedByUserId { get; set; }
        public virtual User User { get; set; } = default!;

        public Guid PurchaseRequestId { get; set; }
        public virtual PurchaseRequest PurchaseRequest { get; set; } = default!;

        public Guid ServiceOrderId { get; set; }
        public virtual ServicesOrder ServicesOrder { get; set; } = default!;

        public string? AdditionalData { get; set; } = "{}";
    }

    public class ServiceOrderRequistionsAdditionalData
    {
        public StatusChangeInformacion? RejectionInformation { get; set; }
        public StatusChangeInformacion? CancellationInformation { get; set; }
    }

    public class StatusChangeInformacion
    {
        public string? Reason { get; set; }
        public UserInformation? UserInformation { get; set; }
    }
}