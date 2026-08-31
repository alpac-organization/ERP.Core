using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Accounting;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class PurchaseRequest : BaseEntity<Guid>
    {
        /// <summary>
        /// Estado logico del dato de la base de datos
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Codigo de la solicitud de comprar unico por solicitud
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Algún concepto o motivo de la solicitud
        /// </summary>
        public string? Concept { get; set; }

        /// <summary>
        /// Motivo de rechazo de la solicitud de compra
        /// </summary>
        public string? ReasonRejection { get; set; }


        /// <summary>
        /// Fecha de la solicitud
        /// </summary>
        public DateOnly RequestDate { get; set; }

        /// <summary>
        /// Fecha que fue revisada la solicitud
        /// </summary>
        public DateOnly? RevisionDate { get; set; }

        /// <summary>
        /// Nivel de prioridad de la solicitud de compra
        /// </summary>
        public PriorityLevel PriorityLevel { get; set; } = PriorityLevel.None;

        /// <summary>
        /// Registro de ubicación del inventario
        /// </summary>
        public DestinationRequest Destination { get; set; } = DestinationRequest.Internal;

        /// <summary>
        /// Tipo de solicitud de requisición
        /// </summary>
        public PurchaseRequestType RequestType { get; set; } = PurchaseRequestType.Requisition;

        /// <summary>
        /// Estado de la solicitud de origen
        /// </summary>
        public PurchaseRequestStatus RequestStatus { get; set; } = PurchaseRequestStatus.Pending;

        /// <summary>
        /// Jefe directo que aprueba las solicitudes de compras en base a su area.
        /// </summary>
        public Guid? UserRevisionId { get; set; }
        public virtual User UserRevision { get; set; } = default!;

        /// <summary>
        /// Usuario que registro la solicitud y area de origin.
        /// </summary>
        public Guid RegisteredByUserId { get; set; }
        public virtual User RegistrationUser { get; set; } = default!;
        
        /// <summary>
        /// Sucursal que necesita la requisición
        /// </summary>
        public Guid BranchId { get; set; }
        public virtual Branch Branch { get; set; } = default!;
        
        /// <summary>
        /// Area Solicitante de los productos.
        /// </summary>
        public Guid AreaId { get; set; }
        public virtual WorkArea WorkArea { get; set;} = default!;

        /// <summary>
        /// Flujo de revisión de solicitudes de compras
        /// </summary>
        public virtual PurchaseOrder? PurchaseOrder { get; set; }
        public virtual PurchaseRequestsReviewedAccounting? AccountingReview { get; set; }
        public virtual PurchaseRequestsReviewedManagement? ManagementReview { get; set; }
        
        /// <summary>
        /// Items solicitados. por el colaborador
        /// </summary>
        public virtual ICollection<PurchaseRequestItem> PurchaseRequestItems { get; set; } = [];
    }
}
