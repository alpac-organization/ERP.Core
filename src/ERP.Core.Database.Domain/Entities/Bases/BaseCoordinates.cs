
namespace ERP.Core.Database.Domain.Entities.Bases
{
   public abstract class BaseCoordinates : BaseEntity<Guid>
   {
      public decimal PositionX { get; set; }
      public decimal PositionY { get; set; }
      public decimal PositionZ { get; set; }
      public decimal RotationY { get; set; }
   }
}