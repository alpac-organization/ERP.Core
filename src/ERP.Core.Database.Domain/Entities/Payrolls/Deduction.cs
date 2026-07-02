using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class Deduction : BaseEntity<Guid>
    {
        public Currency Currency { get; set; }
        public DeductionType Type { get; set; }
        public DeductionStatus Status { get; set; }

        public string? Description { get; set; }

        public int? NumberFortnights { get; set; }
        public int? NumberFortnightsPaid { get; set; }

        public decimal? FortnightlyAmount { get; set; }          //Monto a deducir quincenalmente.
        public decimal? FortnightlyAmountInDollars { get; set; } //Monto Quincenal a deducir en dolares

        public decimal? Amount { get; set; }                // Cantidad Minutos / Otras unidades de medidas
        public int? Percentage { get; set; }                // Esto para embargos, Judiciales y alimenticios


        public decimal? TotalBalance { get; set; }          //Saldo restante que tiene el colaborador por pagar.
        public decimal? TotalBalanceInDollars { get; set; } //Saldo restante que tiene el colaborador por pagar.

        public decimal? AmountPaid { get; set; }           //Total de dinero pagado en cordobas
        public decimal? AmountPaidInDollars { get; set; }  //Total de dinero pagado en dolares

        public decimal TotalAmount { get; set; }          // Monto total de la deducción que se le aplico al colaborador.
        public decimal TotalAmountInDollars { get; set; } // Monto total de la dedución en dolares

        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = null!;
        public virtual ICollection<DeductionPaymentHistory> PaymentHistories { get; set; } = [];
    }
}
