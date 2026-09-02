using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class UnloadingPalletsConfiguration : IEntityTypeConfiguration<UnloadingPallets>
{
    public void Configure(EntityTypeBuilder<UnloadingPallets> builder)
    {
        builder.ToTable("unloading_pallets");
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id)
            .HasColumnName("unloading_pallets_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.UnloadingDetailsId)
            .HasColumnName("unloading_details_id")
            .IsRequired();

        builder.Property(x => x.PalletType)
            .HasColumnName("pallet_type")
            .HasColumnType("pallet_type_enum")
            .IsRequired();

        builder.Property(x => x.Quantity)
            .HasColumnName("quantity")
            .IsRequired();

        builder.Property(x => x.LengthMetres)
            .HasColumnName("length_metres")
            .HasColumnType("numeric(6,2)")
            .IsRequired(false);

        builder.Property(x => x.WidthMetres)
            .HasColumnName("width_metres")
            .HasColumnType("numeric(6,2)")
            .IsRequired(false);

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(x => x.UnloadingDetails)
            .WithMany(x => x.UnloadingPallets)
            .HasForeignKey(x => x.UnloadingDetailsId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}