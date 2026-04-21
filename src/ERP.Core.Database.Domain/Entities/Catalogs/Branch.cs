using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class Branch : BaseEntity<Guid>
    {
        public string? PhoneNumber { get; set; }
        public string? BranchName { get; set; }
        public string? CompanyAlias { get; set; }
        public string? BranchAddress { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = null!;

        //Seccionamientos de nominas.
        public virtual ICollection<Payroll> Payrolls { get; set; } = [];  
    }
}