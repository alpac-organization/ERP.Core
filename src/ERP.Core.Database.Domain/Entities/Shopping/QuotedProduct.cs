using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class QuotedProduct : BaseEntity<Guid>
    {
        public decimal Quantity { get; set; }   
        public string? ProductBrand { get; set; }
        public decimal? QuantityPerUnit { get; set; }
        public string? AdditionalData { get; set; } = "{}";
        public string? Description { get; set;}

        public Guid ProductId  { get; set; }
        public Product Product { get; set; } = default!;

        public Guid UnitMeasureId { get; set; }
        public UnitMeasure UnitOfMeasure { get; set; } = default!;

        public Guid QuotationId { get; set; }
        public Quotation Quotation { get; set; } = default!;
    }

    public class QuotedProductData
    {
        public List<string> ImagesBase64 { get; set; } = [];
    }
}
