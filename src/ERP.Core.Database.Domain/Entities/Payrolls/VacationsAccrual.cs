using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class VacationAccrual : BaseEntity<Guid>
    {
        //Saldo final de vacaciones
        public decimal FinalBalance { get; set; }

        //Saldo inicial de vacaciones
        public decimal BeginningBalance { get; set; }
        
        //Saldo disponible de vacaciones
        public decimal AvailableVacations { get; set; }

        //Cantidad equivalente en cordobas
        public decimal EquivalentQuantity { get; set; }

        //Cantidad equivalente en dolares
        public decimal EquivalentQuantityInDollars { get; set; }

        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = default!;

        public Guid PayrollId { get; set; }
        public virtual Payroll Payroll { get; set; } = default!;
    }
}
