using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Bases.Payroll
{
    public class CollaboratorInformation
    {
        public Guid CollaboratorId { get; set; }

        public string? Fullname { get; set; }
        public string? PictureUrl { get; set; }
        public string? CollaboratorCode { get; set; }
        public string? IdentificationNumber { get; set; }

        public bool DoesWorkSaturdays { get; set; } = false;


        //Otras propiedades
        public string? SecondName { get; set; }
        public string? ThirdName { get; set; }
        public string? SecondLastname { get; set; }
        public string? RegisteredBy { get; set; }

        public CollaboratorStatus Status { get; set; }
        public IdentificationType IdentificationType { get; set; }

        public CompanyInformation CompanyInformation { get; set; } = new();
        public WorkingInformation WorkingInformation { get; set; } = new();
        public PersonalInformation PersonalInformation { get; set; } = new();
    }

    public class PersonalInformation
    {
        public Guid PersonalInformationId { get; set; }

        public string? Address { get; set; }
        public string? PersonalEmail { get; set; }
        public string? PersonalPhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }

        public GenderType Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }

    }

    public class WorkingInformation
    {
        public Guid WorkingInformationId { get; set; }

        public string? Daem { get; set; }
        public string? WorkEmail { get; set; }
        public string? InssNumber { get; set; }
        public string? WorkPhoneNumber { get; set; }
        public string? BankAccountNumber { get; set; }
        
        public BranchInformation BranchInformation { get; set; } = new();
        public WorkAreaInformation WorkAreaInformation { get; set; } = new ();
        public CostCenterInformation CostCenterInformation { get; set; } = new();
        public JobPositionInformation JobPositionInformation { get; set; } = new();

        public DateOnly EntryDate { get; set; }
        public DateOnly? DepartureDate { get; set; }
    }
}