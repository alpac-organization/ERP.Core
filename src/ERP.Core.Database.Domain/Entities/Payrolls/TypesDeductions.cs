using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class TypesDeductions : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public string? DeductionCode { get; set; }
        public string? DeductionTitle { get; set; }
        public string? Description { get; set; }

        //Agregar unidad de medida de la deducción
    }
}