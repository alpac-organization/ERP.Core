using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class UnloadingDetailsConfiguration : IEntityTypeConfiguration<UnloadingDetails>
{
    public void Configure(EntityTypeBuilder<UnloadingDetails> builder)
    {
        builder.ToTable("unloading_details");
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id)
            .HasColumnName("unloading_details_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.WarehouseAssignmentId)
            .HasColumnName("warehouse_assignment_id")
            .IsRequired();

        builder.HasIndex(x => x.WarehouseAssignmentId)
            .IsUnique();

        builder.Property(x => x.MerchandiseType)
            .HasColumnName("merchandise_type")
            .HasColumnType("unloading_merchandise_type_enum")
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(x => x.WarehouseAssignment)
            .WithMany()
            .HasForeignKey(x => x.WarehouseAssignmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}