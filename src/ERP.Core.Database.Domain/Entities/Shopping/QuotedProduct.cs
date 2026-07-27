using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class QuotedProduct : BaseEntity<Guid>
    {
        public bool IsWholesale { get; set; }

        public decimal PricePerUnit { get; set; }
        public decimal? PriceWholesale { get; set; }

        public int Quantity { get; set; }
        public int? EquivalentQuantity { get; set; }  
        public string? AdditionalData { get; set; } = "{}";

        public Guid ProductId  { get; set; }
        public Product Product { get; set; } = default!;

        public Guid UnitOfMeasureId { get; set; }
        public virtual UnitMeasure UnitMeasure { get; set; } = default!;

        public Guid QuoteDetailId { get; set; }
        public virtual QuoteDetail QuoteDetail { get; set; } = default!;
    }

    public class QuotedProductData
    {
        public string? Brand { get; set; }
        public List<string> ImagesBase64 { get; set; } = [];
        public WarrantyInformation WarrantyInformation { get; set; } = new ();
    }

    public class WarrantyInformation
    {
        public bool HasWarranty { get; set; } = false;
        public decimal? QuantityDays { get; set; }
        public decimal? QuantityMonths { get; set; }
    }
}