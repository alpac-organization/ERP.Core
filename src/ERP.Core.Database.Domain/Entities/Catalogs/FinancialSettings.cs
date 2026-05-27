using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class FinancialSettings : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public string? Label { get; set; }
        public decimal Value { get; set; }
        public TaxType TaxType { get; set; }
        public string? Description { get; set; }

        public DateOnly EndDate { get; set; }
        public DateOnly StartDate { get; set; }
    }
}