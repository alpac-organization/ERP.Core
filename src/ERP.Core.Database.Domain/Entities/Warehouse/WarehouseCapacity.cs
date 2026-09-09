using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse
{
    public class WarehouseCapacity : BaseCapacity
    {
        public bool HasMargins { get; set; }

        public decimal? MinimumHeight { get; set; }  // altura para calcular volumen margen
        public decimal? MaximumHeight { get; set; }  // altura para calcular volumen total
        
        public decimal? MarginTop { get; set; }
        public decimal? MarginBottom { get; set; }
        public decimal? MarginRight { get; set; }
        public decimal? MarginLeft { get; set; }

        //M3
        public decimal? UnusedVolumenM3 { get; set; } //volumen inutil: margenes 
        public decimal? AvailableVolumenWithMarginM3 { get; set; }  //volumen util
        public decimal? TotalVolumenM3 { get; set; } 

        public decimal? UnoccupiedChargeableVolumenM3 { get; set; } //Volumen facturable desocupado
        public decimal? OccupiedChargeableVolumenM3 { get; set; } //Volumen facturable ocupado

        public decimal PercentageAvailableVolumenWithMarginM3 { get; set; }

        public Guid WarehouseId { get; set;  }
        public virtual Warehouses Warehouse { get; set; } = null!;
    }
}
