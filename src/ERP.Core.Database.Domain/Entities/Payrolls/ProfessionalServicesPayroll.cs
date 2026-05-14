using System.ComponentModel.DataAnnotations.Schema;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class ProfessionalServicesPayroll: BasePayrollEntity
    {
        [Column(TypeName = "jsonb")]
        public string AlpacAdditionalData { get; set; } = "{}";

        [Column(TypeName = "jsonb")]
        public string VigemsaAdditionalData { get; set; } = "{}";

        [Column(TypeName = "jsonb")]
        public string AvasaAdditionalData { get; set; } = "{}";
    }

    //Vigemsa Prestacionados / Eventuales
    public class VigemsaAdditionalData
    {
        public decimal TotalHoursWorked { get; set; }
        public decimal TotalNumberShiftsPerformed { get; set; }
    } 

    //Alpac Eventuales
    public class AlpacAdditionalData
    {
        
    }
    
    //Avasa Eventuales
    public class AvasaAdditionalData
    {
        
    }
}