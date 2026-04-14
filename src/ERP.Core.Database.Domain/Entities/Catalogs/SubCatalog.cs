using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class SubCatalog : BaseEntity<int>
    {
        public bool IsActive { get; set; }
        public string? CatalogName { get; set; }
        public string? Description { get; set; }

        public int CatalogId { get; set; }
        public virtual Catalog Catalog { get; set; } = null!;
    }
}