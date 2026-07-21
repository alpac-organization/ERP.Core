using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class QuoteDetail : BaseEntity<Guid>
    {
        public int Amount { get; set; }
        public string? Color { get; set; }
        public decimal IndividualPrice { get; set; }

        public string? Observations { get; set; }
        public string? AdditionalData { get; set; } = "{}";

        public Guid UnitMeasureId { get; set; }
        public virtual UnitMeasure UnitMeasure { get; set; } = default!;

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;

        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = default!;

        public Guid QuotationId { get; set; }
        public virtual Quotation Quotation { get; set; } = default!;
    }

    public class QuoteDetailAdditionalData
    {
        public List<string> ImagesBase64 { get; set; } = [];
    }
}
