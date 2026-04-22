using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class WorkingInformation : BaseEntity<Guid>
    {
        public string? BankAccountNumber { get; set; }
        public string? WorkPhoneNumber { get; set; }
        public string? WorkEmail { get; set; }
        public string? InssNumber { get; set; }
        public DateTime? DepartureDate { get; set; }
        
        public Guid CollaboratorId { get; set; }
        
        public int WorkAreaId { get; set; }
        public virtual SubCatalog WorkArea { get; set; } = null!;
        public int WorkPositionId { get; set; }
        public virtual SubCatalog WorkPosition { get; set; } = null!;

        public Guid CompanyBranchId { get; set; }   
        public virtual Branch BranchInfo { get; set; } = null!;
        
        //Fecha de inicio a trabajar
        public DateTime EntryDate { get; set; }

        public virtual Collaborator Collaborator { get; set; } = null!;
    }
}