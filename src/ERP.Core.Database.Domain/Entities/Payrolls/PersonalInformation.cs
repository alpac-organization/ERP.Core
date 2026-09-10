using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class PersonalInformation : BaseEntity<Guid>
    {
        required public Guid CollaboratorId { get; set; }
        public string? Address { get; set; }
        public string? PersonalEmail { get; set; }
        public string? PersonalPhoneNumber { get; set; }

        public DateTime Birthdate { get; set; }

        public GenderType Gender { get; set; } = GenderType.Man;
        public MaritalStatus MaritalStatus { get; set; } = MaritalStatus.None;
        public virtual Collaborator Collaborator { get; set; } = null!;
    }
}