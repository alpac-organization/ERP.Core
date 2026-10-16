using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class Kardex : BaseEntity<Guid>
    {
        public KardexConcept Concept { get; set; }

        public Guid CostCenterId { get; set; }
        public virtual CostCenter CostCenter { get; set; } = default!;

        /// <summary>
        /// Total de unidades de salidas y entradas de productos
        /// </summary>
        public int Units { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalInput { get; set; }
        public decimal TotalOutput { get; set; }
        
        public int TotalUnits { get; set; }
        /// <summary>
        /// Costo promedio
        /// </summary>
        public decimal AverageCost { get; set; }
        public decimal TotalKardex { get; set; }

        public DateOnly TransactionDate { get; set; }
        public TimeOnly TransactionTime { get; set; }


        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;

        public Guid MovementByUserId { get; set; }
        public virtual User User { get; set; } = default!;
    }
}