namespace ERP.Core.Database.Domain.Entities.Bases
{
    public abstract class BaseCapacity : BaseEntity<Guid>
    {
        public decimal Width { get; set; }
        public decimal Length { get; set; }

        //M2
        public decimal UnusedAreaM2 { get; set; }  //area inutil
        public decimal AvailableAreaWithMarginM2 { get; set; }  //area util
        public decimal TotalAreaM2 { get; set; } //Area Total = area util + area inutil = Witdh * Length

        public decimal UnoccupiedChargeableAreaM2 { get; set; } //Area facturable desocupada
        public decimal OccupiedChargeableAreaM2 { get; set; }   //Area facturable ocupada

        public decimal PercentageAvailableAreaWithMarginM2 { get; set; }
    }
}
