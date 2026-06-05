using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    //✅Reporte de pago de viaticos, Quincenal
    public class RecordsTravelExpensePayments : BaseEntity<Guid>
    {
        public int PaidDays { get; set; }
        public decimal Lodging { get; set; }
        public decimal Feeding { get; set; }
        public decimal Transport { get; set; }

        public Guid PayrollId { get; set; }
        public virtual Payroll Payroll { get; set; } = default!;

        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = default!;
    }
}