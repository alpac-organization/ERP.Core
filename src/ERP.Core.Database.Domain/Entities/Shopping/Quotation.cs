using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class Quotation : BaseEntity<Guid>
    {
        public string? MadeBy { get; set; }
        public DateOnly QuoteDate { get; set; }
        public string? Observations { get; set; }
        public decimal ApproximateCostTotal { get; set; }
        public string AdditionalData { get; set; } = "{}";
    }

    public class QuotationAdditionalData
    {
        public List<DetailsQuote> QuotesMade { get; set; } = [];
    }

    public class DetailsQuote
    {
        public required SupplierDetails SupplierDetails { get; set; }
        public List<ProductDetailsQuote> ProductDetailsQuotes { get; set; } = [];
    }

    public class SupplierDetails
    {
        public bool ItsRegistered { get; set; }
        public Guid? SepplierId { get; set; }
        public string? SupplierLegalName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactPhoneNumber { get; set; }
    }

    public class ProductDetailsQuote
    {
        public string? ProductName { get; set; }
        public decimal ProductCost { get; set; }
        public Guid UnitMeasureId { get; set; }
        public string? Observations { get; set; }
        public int AmountProducts { get; set; }

        public List<string> ImagesBase64 { get; set; } = [];
    }

}