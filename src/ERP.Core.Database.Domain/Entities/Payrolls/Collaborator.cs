using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class Collaborator : BaseEntity<Guid>
    {
        public string? PictureUrl { get; set; }
        public string? FirstName { get; set; }
        public string? FirstLastname { get; set; }
        public string? IdentificationNumber { get; set; }
        public string? CollaboratorCode { get; set; }
        public bool DoesWorkSaturdays { get; set; } = false;
        
        //Id de la empresa a la que pertenece este colaborador.
        public Guid CompanyId { get; set; }

        //Otras propiedades
        public string? SecondName { get; set; }
        public string? ThirdName { get; set; }
        public string? SecondLastname { get; set; }
        public string? RegisteredBy { get; set; }

        public GenderType Gender { get; set; }
        public CollaboratorStatus Status { get; set; }
        public IdentificationType IdentificationType { get; set; }

        // Relacionar tablas para acceso a  ellas
        public virtual Company Company { get; set; } = default!;
        public virtual Vacation Vacation { get; set; } = default!;
        public virtual PersonalInformation PersonalInformation { get; set; } = default!;
        public virtual WorkingInformation WorkingInformation { get; set; } = default!;

        //Multiples datos
        public virtual ICollection<Income> Incomes { get; set; } = [];
        public virtual ICollection<Salary> Salaries { get; set; } = [];
        public virtual ICollection<Deduction> Deductions { get; set; } = [];  
        public virtual ICollection<WorkPositionHistory> WorkPositionHistory { get; set; } = [];  
        public virtual ICollection<PermitApplication> PermitApplications { get; set; } = []; 

        
        //Registros de ciclos de nominas
        public virtual ICollection<OrdinaryPayroll> OrdinaryPayrolls { get; set; } = [];
        public virtual ICollection<ProfessionalServicesPayroll> ProfessionalServicesPayrolls { get; set; } = [];


        //Acumulador de vacaciones por quincena
        public virtual ICollection<VacationAccrual> VacationAccruals { get; set; } = [];

        //Acumulador de ir y devengado
        public virtual ICollection<IncomeTaxAccrual> IncomeTaxAccruals { get; set; } = [];

        //Acumulador de aguinaldo
        public virtual ICollection<ChristmasBonusAccrual> ChristmasBonusAccruals { get; set; } = [];

        //Registro de historial de viaticos
        public virtual ICollection<AssignedTravelExpenses> AssignedTravelExpenses { get; set; } = [];

        //Control de pagos de ingresos de viaticos por periodos
        public virtual ICollection<RecordsTravelExpensePayments> RecordsTravelExpensePayments { get; set; } = []; 
    }
}
