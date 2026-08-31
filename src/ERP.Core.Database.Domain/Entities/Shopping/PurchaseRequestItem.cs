using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class PurchaseRequestItem : BaseEntity<Guid>
    {
        /// <summary>
        /// Bandera para verificar si se cotizo este producto.
        /// </summary>
        public bool HasQuotation { get; set; } = false;

        /// <summary>
        /// Cantidad de productos
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Cantidad por unidad.
        /// </summary>
        public int? QuantityUnit { get; set; }
        
        /// <summary>
        /// Descripción del producto.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Justificar por que el cambio o compra de este producto.
        /// </summary>
        public string? Justification { get; set; }

        /// <summary>
        /// Data adicional del producto, como imagenes u otra información adicional
        /// </summary>
        public string? AdditionalData { get; set; }

        public Guid UnitMeasureId { get; set; }
        public virtual UnitMeasure UnitMeasure { get; set; } = default!;

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;

        /// <summary>
        /// Requisición padre y origen
        /// </summary>
        public Guid PurchaseRequestId { get; set; }
        public virtual PurchaseRequest PurchaseRequest { get; set; } = default!;
        
        /// <summary>
        /// Listado Cotizaciones por item.
        /// </summary>
        public virtual ICollection<Quotation> Quotations { get; set; } = [];
    }

    public class PurchaseRequestItemAdditionalData
    {
        public List<string> ImagesProductToChanged { get; set; } = [];
    }
}
