using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse
{
    public class WarehouseCapacity : BaseCapacity
    {
        public bool HasSpaceBetweenWall { get; set; }
        
        public decimal? SpacingTop { get; set; }
        public decimal? SpacingBotton { get; set; }
        public decimal? SpacingRight { get; set; }
        public decimal? SpacingLeft { get; set; }

        public decimal? UnusedSpaceM2 { get; set; }
        public decimal? UnasedSpaceM3 { get; set; } 
        public decimal? AvailableSpaceWithSpacingM3 { get; set; }
        public decimal? AvailableSpaceWithoutSpacingM3 { get; set; }

        public Guid WarehouseId { get; set;  }
        public virtual Warehouses Warehouse { get; set; } = null!;
    }
}
