using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{

    //Reporte de historial de cantidad de viaticos pagados. en cada quincena
    public class AssignedTravelExpensesHistory: BaseEntity<Guid>
    {
        public Guid PayrollId { get; set; }
        public Guid CollaboratorId { get; set; }
        
        public int NumberDaysPaid { get; set; } //Cantidad de dias pagados. esto se calcula en base a los dias que tuvo asistencia el colaborador

        public decimal Feeding { get; set; }
        public decimal Lodging { get; set; }
        public decimal Transport { get; set; }
        public decimal TotalAmountPaid { get; set; }

        // Nomina a la cual esta asociada y el colaborador activos a la que se encuentra
        public virtual Payroll Payroll { get; set; } = default!;
        public virtual Collaborator Collaborator { get; set; } = default!;

        public TravelExpensesStatus Status { get; set; }
    }
}