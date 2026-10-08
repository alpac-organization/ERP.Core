using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs
{
    public class UnitsMeasurementConfiguration : IEntityTypeConfiguration<UnitMeasure>
    {
        public void Configure(EntityTypeBuilder<UnitMeasure> builder)
        {
            builder.ToTable("units_measurement");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("unit_measure_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(e => e.Symbol)
                .HasColumnName("symbol")
                .HasMaxLength(10)
                .IsRequired(false);

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired(false);

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true);

            builder.Property(e => e.Type)
                .HasColumnName("unit_measure_type")
                .HasColumnType("unit_measure_type_enum")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");
        }
    }
}