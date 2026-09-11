using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Bases;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class BasePositionsPalletsConfiguration : IEntityTypeConfiguration<BasePositionsPallets>
{
    public void Configure(EntityTypeBuilder<BasePositionsPallets> builder)
    {
        builder.ToTable("base_posiions_pallets");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("position_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.PositionCode)
            .HasColumnName("position_code")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Row)
            .HasColumnName("row")
            .IsRequired();

        builder.Property(e => e.Column)
            .HasColumnName("column")
            .IsRequired();

        builder.Property(e => e.Level)
            .HasColumnName("level")
            .IsRequired();

        builder.Property(e => e.Status)
            .HasColumnName("status")
            .HasColumnType("rack_status_enum")
            .HasDefaultValueSql("'available'::rack_status_enum")
            .IsRequired();

        builder.Property(e => e.AllowsStocking)
            .HasColumnName("allows_stocking")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.Observations)
            .HasColumnName("observations")
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

    }
}