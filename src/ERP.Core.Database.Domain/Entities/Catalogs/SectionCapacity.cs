using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class SectionCapacity : BaseCapacity
    {        
        public Guid SectionId { get; set; }
        public virtual Sections Section { get; set; } = null!;
    }
}
