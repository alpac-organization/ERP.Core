using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class Quotation : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public bool HasDelivery { get; set; }
        public bool HasGuarantee { get; set; }
        public bool InventoryAvailable { get; set; }
        public bool IsAcceptedForPurchase { get; set; }

        public decimal Iva { get; set; }
        public decimal PriceUnit { get; set; }
        public decimal PriceTotal { get; set; }
      public string? SupplierSelectionJustification { get; set; }
      
      public int? SupplierRejectionReasonId { get; set; }
      public virtual SubCatalog? SupplierRejectionReason { get; set; }
      public string? SupplierRejectionComments { get; set; }

        public ProductQuality ProductQuality { get; set; }
        public PaymentMethodType PaymentMethodType { get; set; }

        public DateOnly QuoteDate { get; set; }
        public string? BrandProduct { get; set; }

        public decimal? DeliveryTime { get; set; }
        public TimeType? DeliveryTimeType { get; set; }

        public decimal? WarrantyPeriod { get; set; }
        public TimeType? WarrantyPeriodTimeType { get; set; }

        public decimal? AvailabilityTime { get; set; }
        public TimeType? AvailabilityTimeType { get; set; }

        /// <summary>
        /// Data adicional de la cotización las imágenes y documentos pdf.
        /// </summary>
        public string? AdditionalData { get; set; }

        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = default!;

        public Guid PurchaseRequestItemId { get; set; }
        public virtual PurchaseRequestItem PurchaseRequestItem { get; set; } = default!;
    }

    public class QuotationAdditionalData
    {
        public List<QuotationFileInformation> Images { get; set; } = [];

        public List<QuotationFileInformation> Documents { get; set; } = [];
    }

    public class QuotationFileInformation
    {
        public Guid FileId { get; set; } = Guid.NewGuid();
        public string FileName { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}
