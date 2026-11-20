using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    // Representa un período  un colaborador.
    public class CollaboratorPeriod : BaseEntity<Guid>
    {
        public Guid CollaboratorId { get; set; }

        public virtual Collaborator Collaborator { get; set; } = null!;

        public string CollaboratorCode { get; set; } = string.Empty;

        // Fecha efectiva de inicio de este vínculo laboral.
        public DateOnly EntryDate { get; set; }

        // Fecha efectiva de finalización de este vínculo.
        public DateOnly? DepartureDate { get; set; }

        // Terminación que cerró este período laboral.
        public Guid? CollaboratorTerminationId { get; set; }

        public virtual CollaboratorTermination? CollaboratorTermination { get; set; }

        public virtual ICollection<ChristmasBonusAccrual> ChristmasBonusAccruals { get; set; } = [];

        public virtual ICollection<ChristmasBonusAdvance> ChristmasBonusAdvances { get; set; } = [];

        public virtual ICollection<ChristmasBonusSettlement> ChristmasBonusSettlements { get; set; } = [];
    }
}