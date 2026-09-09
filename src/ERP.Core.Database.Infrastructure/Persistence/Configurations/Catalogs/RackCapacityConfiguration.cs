using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class RackCapacityConfiguration : IEntityTypeConfiguration<RackCapacity>
{
    public void Configure(EntityTypeBuilder<RackCapacity> builder)
    {
        builder.ToTable("rack_capacities");

        builder.Property(rc => rc.RackId)
            .HasColumnName("rack_id")
            .IsRequired();

        builder.HasOne(rc => rc.Rack)
            .WithOne(r => r.RackCapacity)
            .HasForeignKey<RackCapacity>(rc => rc.RackId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(c => c.Height)
            .HasColumnName("height")
            .HasPrecision(18, 2)
            .IsRequired(false);
    }
}
