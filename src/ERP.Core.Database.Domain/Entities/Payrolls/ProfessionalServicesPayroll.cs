using ERP.Core.Database.Domain.Entities.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class ProfessionalServicesPayroll: BasePayrollEntity
    {
        [Column(TypeName = "jsonb")]
        public string VigemsaAdditionalData { get; set; } = "{}";

        public virtual ICollection<AssistanceControl> AssistanceControls { get; set; } = [];
    }

    //Vigemsa Prestacionados / Eventuales
    public class VigemsaAdditionalData
    {
        //Total de horas de trabajo laborada
        public decimal TotalHoursWorked { get; set; }

        //Total de turnos realizados
        public decimal TotalNumberShiftsPerformed { get; set; }

        public decimal NetToPay { get; set; }
    } 
}