using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Operations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Operations;

public class AssigmentEnclosureConfiguration : IEntityTypeConfiguration<AssignmentEnclosure>
{
    public void Configure(EntityTypeBuilder<AssignmentEnclosure> builder)
    {
        builder.ToTable("assignment_enclosure");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("assignment_enclosure_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(e => e.WarehouseId)
            .HasColumnName("warehosue_id")
            .IsRequired(false);

        builder.Property(e => e.DestinationType)
            .HasColumnName("destination_type")
            .HasColumnType("destination_type_enum")
            .HasDefaultValueSql("'Warehouse'::destination_type_enum")
            .IsRequired();

        builder.Property(e => e.Observations)
            .HasColumnName("observations")
            .HasMaxLength(1000)
            .IsRequired(false);

        builder.Property(e => e.Merchandise)
            .HasColumnName("merchandise")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(e => e.MerchandiseDescription)
            .HasColumnName("merchandise_description")
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(e => e.Warehouse)
            .WithMany(w => w.AssignmentEnclosures)
            .HasForeignKey(e => e.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}