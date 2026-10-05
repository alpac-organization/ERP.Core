using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
   public class SupplierProductTierPrice:BaseEntity<Guid>
   {
      //Minima cantidad para precio preferencial 
      public int MinQuantity {get; set; } 
      public DateOnly ValidFrom {get; set;}
      public DateOnly ValidTo {get; set;}

      //precio preferencial de supplier-product
      public decimal PreferencialPrice {get; set;}
      public Guid SupplierProductId { get; set;} 
      public virtual SupplierProduct SupplierProduct {get; set;} = default!;

      // Esto quedria optional. Si es null, se asume la UnitMeasureId del Product como tal.
      public Guid? UnitMeasureId {get; set;}
      public virtual UnitMeasure? UnitMeasure {get; set;} = default!;
   }
}