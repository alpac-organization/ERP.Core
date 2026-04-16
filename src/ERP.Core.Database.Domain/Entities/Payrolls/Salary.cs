using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class Salary : BaseEntity<Guid>
    {
        public Guid CollaboratorId { get; set; }

        public decimal AmountInLocal { get; set; }
        public decimal AmountInForeign { get; set; }
        public decimal AmountSalary { get; set; }

        public int BankSubCatalogId { get; set; }
        public Currency Currency { get; set; }
        public SalaryType SalaryType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Collaborator Collaborator { get; set; } = null!;
    }
}   