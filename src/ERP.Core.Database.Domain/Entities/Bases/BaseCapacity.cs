namespace ERP.Core.Database.Domain.Entities.Bases
{
    public abstract class BaseCapacity : BaseEntity<Guid>
    {
        public decimal Witdh { get; set; }
        public decimal Length { get; set; }

        //M2
        public decimal UnusedAreaM2 { get; set; }  //area inutil
        public decimal AvailableAreaWithSpacingM2 { get; set; }  //area util
        public decimal TotalAreaM2 { get; set; } //Area Total = area util + area inutil = Witdh * Length

        public decimal VacantChargeableAreaM2 { get; set; } //Area Disponible para Cobro
        public decimal OccupiedChargeableAreaM2 { get; set; } //Area Ocupada para Cobrar

        public decimal PercenteAvailableAreaWithSpacingM2 { get; set; }
        public decimal PercenteAvailableVolumenWithSpacingM3 { get; set; }
    }
}
