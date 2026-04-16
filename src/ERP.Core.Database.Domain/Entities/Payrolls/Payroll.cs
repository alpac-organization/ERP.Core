using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class Payroll : BaseEntity<Guid>
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } 
        public decimal TotalToPay { get; set; }
        public PayrollStatus Status { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = default!;

        public virtual ICollection<OrdinaryPayroll> OrdinaryPayrolls { get; set; } = [];
    }
}