using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class Income : BaseEntity<Guid>
    {
        public decimal Amount { get; set; }
        public IncomeType IncomeType { get; set; }
        public string? Description { get; set; }
    }
}