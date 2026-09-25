using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Operations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Operations;

public class AssignmentsMachineryConfiguration : IEntityTypeConfiguration<AssignmentsMachinery>
{
    public void Configure(EntityTypeBuilder<AssignmentsMachinery> builder)
    {
        builder.ToTable("assignments_machinery");

        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id)
            .HasColumnName("assignment_machinery_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(ac => ac.OperationalOrderId)
            .HasColumnName("operational_order_id")
            .IsRequired();

        builder.Property(x => x.MachineryId)
            .HasColumnName("machinery_id")
            .IsRequired();

        builder.Property(ac => ac.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(ac => ac.OperationalOrder)
            .WithMany(o => o.AssignmentsMachineries)
            .HasForeignKey(ac => ac.OperationalOrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ac => ac.Machinery)
            .WithMany()
            .HasForeignKey(ac => ac.MachineryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(ac => ac.OperationalOrderId)
            .HasDatabaseName("ix_assignments_machinery_operational_order_id");

        builder.HasIndex(ac => ac.MachineryId)
            .HasDatabaseName("ix_assignments_machinery_machinery_id");
    }
}
