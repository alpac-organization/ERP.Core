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
        
        /// <summary>
        /// Pendiente
        /// </summary>
        public Guid JobPositionId { get; set; }
        public virtual JobPosition JobPosition { get; set; } = null!;

        /// <summary>
        /// Area designada del colaborador
        /// </summary>
        public Guid AreaId { get; set; }
        public virtual WorkArea Area { get; set; } = default!;

        /// <summary>
        /// Sucursal Designada donde esta ubicado el colaborador
        /// </summary>
        public Guid BranchId { get; set; }
        public virtual Branch Branch { get; set; } = null!;

        /// <summary>
        /// Entidad padre colaborador
        /// </summary>
        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = null!;

        /// <summary>
        /// Centro costo designado
        /// </summary>
        public Guid? CostCenterId { get; set; }
        public virtual CostCenter CostCenter { get; set; } = default!;

        public DateOnly EntryDate { get; set; } //Fecha de entrada del colaborador a la empresa.
        public DateOnly? DepartureDate { get; set; } //Fecha de baja del colaborador.
    }
}