using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class Deduction : BaseEntity<Guid>
    {
        public DeductionType Type { get; set; }
        public DeductionStatus Status { get; set; }
        public string? Description { get; set; }

        public int NumberOfFortnights { get; set; }

        public decimal FortnightlyAmount { get; set; }  //Monto a deducir quincenalmente.
        public decimal TotalAmount { get; set; }        //Monto total de la deducción que se le aplico al colaborador.
        public decimal TotalBalance { get; set; }       //Saldo restante que tiene el colaborador por pagar.
        public decimal AmountPaid { get; set; }         //Todal de dinero pagado por el colaborador

        public DateTime DeductionStartDate { get; set; }

        public Guid CollaboratorId { get; set;}
        public virtual Collaborator Collaborator { get; set; } = null!;

        public virtual ICollection<DeductionPaymentHistory> PaymentHistories { get; set; } = [];  

    }
}
