using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class PersonalInformation : BaseEntity<Guid>
    {
        required public Guid CollaboratorId { get; set; }
        public string? PersonalEmail { get; set; }
        public string? PersonalPhoneNumber { get; set; }
        public string? Address { get; set; }

        public int? DepartamentId { get; set; }
        public virtual SubCatalog? Departament { get; set; } = null!;

        public DateTime Birthdate { get; set; }
        public MaritalStatus MaritalStatus { get; set; } = MaritalStatus.None;
        public virtual Collaborator Collaborator { get; set; } = null!;
    }
}