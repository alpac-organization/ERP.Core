using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class PhysicalCountLine : BaseEntity<Guid>
    {
        public Guid PhysicalCountId { get; set; }
        public Guid ProductStockId { get; set; }
        public decimal SystemStock { get; set; }
        public decimal? PhysicalStock { get; set; }
        public decimal? Difference { get; set; }
        public string? Observations { get; set; }
        public Guid? CountedByUserId { get; set; }
        public DateTime? CountedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual PhysicalCount PhysicalCount { get; set; } = default!;
        public virtual ProductStock ProductStock { get; set; } = default!;
    }
}