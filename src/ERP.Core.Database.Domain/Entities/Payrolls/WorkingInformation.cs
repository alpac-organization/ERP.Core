using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class WorkingInformation : BaseEntity<Guid>
    {
        public string? Daem { get; set; }
        public string? WorkEmail { get; set; }
        public string? InssNumber { get; set; }
        public string? WorkPhoneNumber { get; set; }
        public string? BankAccountNumber { get; set; }
        
        
        public int WorkAreaId { get; set; }
        public virtual SubCatalog WorkArea { get; set; } = null!;
        public int WorkPositionId { get; set; }
        public virtual SubCatalog WorkPosition { get; set; } = null!;

        public Guid CompanyBranchId { get; set; }   
        public virtual Branch BranchInfo { get; set; } = null!;



        //Nuevas Relaciones
        public Guid AreaId { get; set; }
        public Guid BranchId { get; set; }    
        public Guid JobPositionId { get; set; }

        public DateOnly EntryDate { get; set; } //Fecha de entrada del colaborador a la empresa.
        public DateOnly? DepartureDate { get; set; } //Fecha de baja del colaborador.


        //Relacioón con entidad colaborador.
        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = null!;
    }
}