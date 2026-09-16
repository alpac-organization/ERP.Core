

using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs
{
   public class LotsCoordinatesConfiguration : IEntityTypeConfiguration<LotsCoordinates>
   {
      public void Configure(EntityTypeBuilder<LotsCoordinates> builder)
      {
         builder.ToTable("lot_coordinates");

        builder.Property(lc => lc.LotId)
            .HasColumnName("lot_id")
            .IsRequired();

        builder.HasIndex(lc => lc.LotId)
            .IsUnique()
            .HasDatabaseName("ux_lot_coordinates_lot_id");

        builder.HasOne(lc => lc.Lot)
            .WithOne(s => s.LotsCoordinates)
            .HasForeignKey<LotsCoordinates>(lc => lc.LotId)
            .OnDelete(DeleteBehavior.Restrict);
      }
   }
}