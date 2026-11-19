using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class ChristmasBonusPeriod : BaseEntity<Guid> 
    {
        public Guid CompanyId { get; set; }

        public virtual Company Company { get; set; } = default!;

        public int EndYear { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public ChristmasBonusPeriodStatus Status { get; set; }

        public virtual ICollection<ChristmasBonusAccrual> Accruals { get; set; } = [];

        public virtual ICollection<ChristmasBonusAdvance> Advances { get; set; } = [];

        public virtual ICollection<ChristmasBonusSettlement> Settlements { get; set; } = [];
    }
}