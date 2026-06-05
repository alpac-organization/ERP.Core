using ERP.Core.Database.Domain.Entities.Bases;

//Nominas Contables
namespace ERP.Core.Database.Domain.Entities.Payrolls
{

    //Tipos de nominas contables que estan disponibles.
    public class TypesAccountingPayroll : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public string? AccountingPayrollName  { get; set; }
        public string? AccountingPayrollCode { get; set; }
    }
}