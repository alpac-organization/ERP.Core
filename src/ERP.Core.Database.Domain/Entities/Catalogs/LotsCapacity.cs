using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class LotsCapacity : BaseCapacity
    {
        public Guid LotsId { get; set; }
        public virtual Lots Lot { get; set; } = null!;
    }
}
