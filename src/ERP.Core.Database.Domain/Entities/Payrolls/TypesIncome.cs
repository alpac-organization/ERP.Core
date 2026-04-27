using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class TypesIncome : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public string? IncomeTitle { get; set; }
        public string? IncomeDescription { get; set; }
    }
}