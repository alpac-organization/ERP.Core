using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse
{
    public class WarehouseCapacity : BaseCapacity
    {
        public bool HasSpaceBetweenWall { get; set; }

        public decimal? MinimumHeight { get; set; }
        public decimal? MaximumHeight { get; set; }
        
        public decimal? SpacingTop { get; set; }
        public decimal? SpacingBotton { get; set; }
        public decimal? SpacingRight { get; set; }
        public decimal? SpacingLeft { get; set; }

        //M3
        public decimal? UnasedVolumenM3 { get; set; } 
        public decimal? AvailableVolumenWithSpacingM3 { get; set; }
        public decimal? AvailableVolumenWithoutSpacingM3 { get; set; }

        public decimal? VacantChargeableVolumenM3 { get; set; } //Volumen Disponible para Cobro
        public decimal? OccupiedChargeableVolumenM3 { get; set; } //Volumen Ocupado para Cobrar
        
        
        public Guid WarehouseId { get; set;  }
        public virtual Warehouses Warehouse { get; set; } = null!;
    }
}
