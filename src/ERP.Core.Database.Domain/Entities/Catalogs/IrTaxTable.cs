using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class IrTaxTable : BaseEntity<Guid>
    {
        // El límite inferior del estrato (ej. 100,000.01)
        public decimal FromAmount { get; set; }
        
        // El límite superior (ej. 200,000.00). Nulable para el "a más"
        public decimal? ToAmount { get; set; }
        
        // El impuesto base (la columna del centro en tu imagen, ej. 15,000.00)
        public decimal BaseTax { get; set; }
        
        // El porcentaje aplicable sobre el exceso (ej. 0.15 para 15%)
        public decimal Percentage { get; set; }
        
        // El monto sobre el cual se calcula el exceso (ej. 100,000.00)
        public decimal OverExcessAmount { get; set; }


        //Control de auditoria.
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Status { get; set; }
    }
}