using System.ComponentModel.DataAnnotations.Schema;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class OrdinaryPayroll: BasePayrollEntity
    {
        public decimal BiweeklySalary { get; set; } //Salario Quincenal sin deducciones

        public decimal Bonus { get; set; }
        public decimal Overtime { get; set; }
        public int NumberOfOvertime { get; set; }
        public decimal GrossSalary { get; set; } //Donde le sumamos horas extras y bonos


        [Column(TypeName = "jsonb")] 
        public string DeductionsAdditionalData { get; set; } = "{}"; //Json con toda la información de deducciones posibles que existen para el colaborador.
        public decimal TotalDeducctions { get; set; }

        public decimal Vacations { get; set; } //Vacaciones
        public decimal TravelExpenses { get; set; } // Viaticos del colaborador
    }

    public class DeductionsAdditionalData
    {
        public decimal Loans { get; set; } = 0.0m; // Prestamos
        public decimal Purisima { get; set; } = 0.0m; // Purisima
        public decimal ChildSupportGarnishment { get; set; } = 0.0m;// Embargo Alimenticio
        
        public decimal SalaryAdvance { get; set; } = 0.0m;// Adelanto de salario
        public decimal ChristmasBonusAdvance { get; set; } = 0.0m; //Adelanto de aguinaldo

        public decimal JudicialSeizures { get; set; } = 0.0m;  // Embargo judicial
        public decimal UniformDeduction { get; set; } = 0.0m; // Deducción por camisetas de la empresa

        public decimal CashShortage { get; set; } = 0.0m;     //Faltante de caja
        public decimal OtherDeductions { get; set; } = 0.0m;   //Otras deducciones
        public decimal DeductionForLossesBulk { get; set; } = 0.0m; // Deducción por perdidas de bultos.

        public decimal Absences { get; set; } = 0.0m;//Ausencias
        public decimal Sanction { get; set; } = 0.0m;//Sanción
        public decimal LateArrivals { get; set; } = 0.0m; // Llegadas Tardes
    }
}