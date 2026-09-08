using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class SectionCapacity : BaseCapacity
    {
        public decimal? UsableAreaM2 { get; set; }
        public decimal? UnusableAreaM2 { get; set; }
        
        public Guid SectionId { get; set; }
        public virtual Sections Section { get; set; } = null!;
    }
}
