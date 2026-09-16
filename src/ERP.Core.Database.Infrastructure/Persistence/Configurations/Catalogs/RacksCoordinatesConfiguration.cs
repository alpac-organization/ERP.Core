

using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs
{
   public class RacksCoordinatesConfiguration : IEntityTypeConfiguration<RacksCoordinates>
   {
      public void Configure(EntityTypeBuilder<RacksCoordinates> builder)
      {
         builder.ToTable("rack_coordinates");

         builder.Property(rc => rc.RackId)
             .HasColumnName("rack_id")
             .IsRequired();

         builder.HasIndex(rc => rc.RackId)
             .IsUnique()
             .HasDatabaseName("ux_rack_coordinates_rack_id");

         builder.HasOne(rc => rc.Rack)
             .WithOne(s => s.RacksCoordinates)
             .HasForeignKey<RacksCoordinates>(rc => rc.RackId)
             .OnDelete(DeleteBehavior.Restrict);
      }
   }
}