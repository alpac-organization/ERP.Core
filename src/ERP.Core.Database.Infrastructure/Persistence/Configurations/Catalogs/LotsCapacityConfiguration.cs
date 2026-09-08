using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class LotsCapacityConfiguration : IEntityTypeConfiguration<LotsCapacity>
{
    public void Configure(EntityTypeBuilder<LotsCapacity> builder)
    {
        builder.ToTable("lots_capacities");

        builder.Property(lc => lc.LotsId)
            .HasColumnName("lots_id")
            .IsRequired();

        builder.HasOne(lc => lc.Lot)
            .WithOne(l => l.LotsCapacity)
            .HasForeignKey<LotsCapacity>(lc => lc.LotsId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
