using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
   public class LotsCoordinates : BaseCoordinates
   {
      public Guid LotId { get; set; }
      public virtual Lots Lot { get; set; } = null!;
   }
}