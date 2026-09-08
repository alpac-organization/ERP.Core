namespace ERP.Core.Database.Domain.Entities.Bases
{
    public abstract class BaseCapacity : BaseEntity<Guid>
    {
        public decimal Witdh { get; set; }
        public decimal Length { get; set; }

        //M2
        public decimal? UnusedSpaceM2 { get; set; }
        public decimal AvailableSpaceWithSpacingM2 { get; set; }
        public decimal AvailableSpaceWithoutSpacingM2 { get; set; }

        public decimal PercenteAvailableSpaceWithSpacingM2 { get; set; }
        public decimal PercenteAvailableSpaceWithSpacingM3 { get; set; }
    }
}
