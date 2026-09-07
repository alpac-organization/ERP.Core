using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse
{
    public class Capacity : BaseEntity<Guid>
    {
        public bool HasSpaceBetweenWall { get; set; }

        public decimal Witdh { get; set; }
        public decimal Length { get; set; }
        public decimal? MinimumHeight { get; set;}
        public decimal? MaximumHeight { get; set; }

        public decimal AvailableSpaceWithSpacingM2 { get; set; }
        public decimal AvailableSpaceWithoutSpacingM2 { get; set; }

        public decimal PercenteAvailableSpaceWithSpacingM2 { get; set; }
        public decimal PercenteAvailableSpaceWithSpacingM3 { get; set; }

        public decimal? AvailableSpaceWithSpacingM3 { get; set; }
        public decimal? AvailableSpaceWithoutSpacingM3 { get; set;  }

        public decimal? SpacingTop { get; set; }
        public decimal? SpacingBotton { get; set; }
        public decimal? SpacingRight { get; set; }
        public decimal? SpacingLeft { get; set; }

        public decimal? UnusedSpaceM2 { get; set; }
        public decimal? UnasedSpaceM3 { get; set; }
        

        /// <summary>
        /// Todas las entidades con capacidades matematicas de almacenamiento.
        /// </summary>
        public virtual Lots Lots { get; set; } = null!;
        public virtual Racks Racks { get; set; } = null!;
        public virtual Sections Section { get; set; } = null!;
        public virtual Warehouses Warehouse { get; set; } = null!;
    }   
}