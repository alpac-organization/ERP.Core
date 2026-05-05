using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class Payroll : BaseEntity<Guid>
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public PayrollStatus Status { get; set; }
        public PayrollType PayrollType { get; set; }

        public Guid BranchId { get; set; }
        public virtual Branch Branch { get; set; } = null!;
        
        public virtual ICollection<OrdinaryPayroll> OrdinaryPayrolls { get; set; } = [];
        public virtual ICollection<IncomeTaxAccrual> IncomeTaxAccruals { get; set; } = []; 
        public virtual ICollection<AssignedTravelExpensesHistory> AssignedTravelExpensesHistories { get; set; } = [];
    }
}