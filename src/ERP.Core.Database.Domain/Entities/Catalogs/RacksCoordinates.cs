using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
   public class RacksCoordinates : BaseCoordinates
   {
      public Guid RackId { get; set; }
      public virtual Racks Rack { get; set; } = null!;
   }
}