using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Payroll
{
    public class WorkPositionHistory : BaseEntity<Guid>
    {
        public Guid CollaboratorId { get; set; }

        public int WorkPositionId { get; set; }
        public virtual SubCatalog WorkPosition { get; set; } = null!;
 
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } = null;

        public virtual Collaborator Collaborator { get; set; } = null!;
    }
}