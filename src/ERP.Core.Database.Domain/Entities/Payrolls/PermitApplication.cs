using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class PermitApplication : BaseEntity<Guid>
    {
        public string? CollaboratorCode { get; set; }
        
        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = null!;

        public Guid PayrolId { get; set; }
        public virtual Payroll Payroll { get; set; } = null!;

        public PermitApplicationType Type { get; set; }
        public PermitApplicationStatus Status { get; set; }


        [Column(TypeName = "jsonb")] 
        public string AdditionalData { get; set; } = "{}";

        public bool? FirtsStepApproved { get; set; } = null;
        public bool? SecondStepApproved { get; set; } = null;

        public string? ManagerFullname { get; set; }
        public string? AdministratorFullName { get; set; }

        public decimal? AmountDays { get; set; }
        public string? IdentificationCollaboratorToReceive { get; set; }

        public string? RequestedBy { get; set; }
        public string? Description { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }

    }
}