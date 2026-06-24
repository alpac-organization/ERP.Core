using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    //Control de asistencia para guardas de seguridad
    public class AssistanceControl : BaseEntity<Guid>
    {
        //Fecha de registro de vigilancia
        public DateOnly ShiftDate { get; set; }

        //Cantidad de horas trabajadas
        public decimal AmountHours { get; set; }

        public Guid ProfessionalPayrollId { get; set; }
        public virtual ProfessionalServicesPayroll ProfessionalServicesPayroll { get; set; } = default!;
    }
}