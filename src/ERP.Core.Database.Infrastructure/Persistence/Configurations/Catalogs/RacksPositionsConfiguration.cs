using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class RackPositionsConfiguration : IEntityTypeConfiguration<RackPositions>
{
    public void Configure(EntityTypeBuilder<RackPositions> builder)
    {
        builder.ToTable("rack_positions");

        builder.Property(e => e.RackId)
            .HasColumnName("rack_id")
            .IsRequired();

        builder.HasIndex(e => e.RackId)
            .HasDatabaseName("ix_rack_positions_rack_id");

        builder.HasOne(e => e.Rack)
            .WithMany(r => r.Positions)
            .HasForeignKey(e => e.RackId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}