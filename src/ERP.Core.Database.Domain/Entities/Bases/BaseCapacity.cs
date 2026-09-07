namespace ERP.Core.Database.Domain.Entities.Bases
{
    public abstract class BaseCapacity : BaseEntity<Guid>
    {
        public decimal Witdh { get; set; }
        public decimal Length { get; set; }
        public decimal? MinimumHeight { get; set; }
        public decimal? MaximumHeight { get; set; }
        
        public decimal AvailableSpaceWithSpacingM2 { get; set; }
        public decimal AvailableSpaceWithoutSpacingM2 { get; set; }

        public decimal PercenteAvailableSpaceWithSpacingM2 { get; set; }
        public decimal PercenteAvailableSpaceWithSpacingM3 { get; set; }
    }
}
