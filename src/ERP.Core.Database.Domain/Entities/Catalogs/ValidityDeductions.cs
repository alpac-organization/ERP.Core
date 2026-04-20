using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class ValidityDeductions : BaseEntity<Guid>
    {
        public bool Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Value { get; set; }
        public string? TitleTax { get; set; }
        public string? Description { get; set; }
        public TaxType Type { get; set; }
    }
}