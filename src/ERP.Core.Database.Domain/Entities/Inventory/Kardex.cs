using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class Kardex : BaseEntity<Guid>
    {
        public KardexType KardexType { get; set; }
        public KardexMovementType MovementType { get; set; }

        /// <summary>
        /// Total de unidades de salidas y entradas de productos
        /// </summary>
        public int Units { get; set; }

        /// <summary>
        /// Costo por unidad
        /// </summary>
        public decimal UnitCost { get; set; }

        /// <summary>
        /// Total de entrada de dinero
        /// </summary>
        public decimal TotalInput { get; set; }

        /// <summary>
        /// Total de salida de dinero
        /// </summary>
        public decimal TotalOutput { get; set; }
        
        /// <summary>
        /// Totol de unidades de existencias
        /// </summary>
        public int TotalUnits { get; set; }

        /// <summary>
        /// Costo promedio
        /// </summary>
        public decimal AverageCost { get; set; }


        /// <summary>
        /// Total del kardex
        /// </summary>
        public decimal TotalKardex { get; set; }

        public DateOnly TransactionDate { get; set; }
        public TimeOnly TransactionTime { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;

        /// <summary>
        /// Movimiento realizado por el usuario tal..
        /// </summary>
        public Guid MovementByUserId { get; set; }
        public virtual User User { get; set; } = default!;

        /// <summary>
        /// Area del centro de costo
        /// </summary>
        public Guid WorkAreaId { get; set; }
        public virtual WorkArea WorkArea { get; set; } = default!;

        /// <summary>
        /// Centro de costo cargado
        /// </summary>
        public Guid CostCenterId { get; set; }
        public virtual CostCenter CostCenter { get; set; } = default!;
    }
}