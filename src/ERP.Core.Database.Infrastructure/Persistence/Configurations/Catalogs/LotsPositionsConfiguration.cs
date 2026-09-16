using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class LotsPositionsConfiguration : IEntityTypeConfiguration<LotsPositions>
{
    public void Configure(EntityTypeBuilder<LotsPositions> builder)
    {
        builder.ToTable("lots_positions");

        builder.Property(e => e.LotId)
            .HasColumnName("lot_id")
            .IsRequired();

        builder.HasIndex(e => e.LotId)
            .HasDatabaseName("ix_lots_positions_lot_id");

        builder.HasOne(e => e.Lot)
            .WithMany(l => l.Positions)
            .HasForeignKey(e => e.LotId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
