using ERP.Core.Database.Domain.Entities.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class OrdinaryPayroll: BasePayrollEntity
    {
        public decimal BiweeklySalary { get; set; } //Salario Quincenal sin deducciones

        [Column(TypeName = "jsonb")] 
        public string DeductionsAdditionalData { get; set; } = "{}"; //Json con toda la información de deducciones posibles que existen para el colaborador.
        public decimal TotalDeducctions { get; set; }
        
        public decimal Antique { get; set; }
        public decimal TotalIncome { get; set; }

        public decimal Transport { get; set; }
        public decimal Feeding { get ; set; }
        public decimal Lodging { get; set; }
        public decimal TotalTravelExpenses { get; set; }
    }

    public class DeductionsAdditionalData
    {
        public decimal Loans { get; set; } = 0.0m; // Prestamos
        public decimal Purisima { get; set; } = 0.0m; // Purisima
        public decimal OtherDeductions { get; set; } = 0.0m;   //Otras deducciones
        
        public decimal LateArrivalsInMinutes { get; set; } = 0.0m;
        public decimal LateArrivals { get; set; } = 0.0m; // Llegadas Tardes

        public decimal JudicialSeizures { get; set; } = 0.0m;  // Embargo judicial
        public decimal ChildSupportGarnishment { get; set; } = 0.0m;// Embargo Alimenticio
        
        public decimal SalaryAdvance { get; set; } = 0.0m;// Adelanto de salario
        public decimal ChristmasBonusAdvance { get; set; } = 0.0m; //Adelanto de aguinaldo
        public decimal UniformDeduction { get; set; } = 0.0m; // Deducción por camisetas de la empresa

        public decimal CashShortage { get; set; } = 0.0m;     //Faltante de caja
        public decimal DeductionForLossesBulk { get; set; } = 0.0m; // Deducción por perdidas de bultos.

        public decimal Absences { get; set; } = 0.0m;//Ausencias
        public decimal Sanction { get; set; } = 0.0m;//Sanción

    }
}