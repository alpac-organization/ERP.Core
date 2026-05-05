using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class AssignedTravelExpenses : BaseEntity<Guid>
    {
        //Los Viaticos se aplican en moneda cordobas
        public decimal AmountInDollars { get; set; }
        public decimal AmountInLocalCurrency { get; set; }
        public Currency Currency { get; set; } = Currency.NIO;

        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = default!;

        public Guid TypeIncomeId { get; set; }
        public virtual TypesIncome TypeIncome { get; set; } = default!;

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}