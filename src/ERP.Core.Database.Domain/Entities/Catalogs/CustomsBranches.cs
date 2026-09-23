using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class CustomsBranches : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public string? Code { get; set; }
        public string? CustomsBranchName { get; set; }

        public virtual ICollection<ReceptionEntrance> ReceptionEntrances { get; set; } = [];
    }
}
