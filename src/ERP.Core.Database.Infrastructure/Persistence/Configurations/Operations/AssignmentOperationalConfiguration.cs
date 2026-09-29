using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Operations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Operations
{
    public class AssignmentOperationalConfiguration : IEntityTypeConfiguration<AssignmentOperational>
    {
        public void Configure(EntityTypeBuilder<AssignmentOperational> builder)
        {
            builder.ToTable("assignment_operational");

            builder.HasKey(ao => ao.Id);

            builder.Property(ao => ao.Id)
                .HasColumnName("assignment_operational_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ao => ao.OperationalOrderId)
                .HasColumnName("operational_order_id")
                .IsRequired();

            builder.Property(e => e.WarehouseId)
                .HasColumnName("warehosue_id")
                .IsRequired(false);

            builder.Property(e => e.DestinationType)
                .HasColumnName("destination_type")
                .HasColumnType("destination_type_enum")
                .HasDefaultValueSql("'warehouse'::destination_type_enum")
                .IsRequired();

            builder.Property(e => e.Observations)
                .HasColumnName("observations")
                .HasMaxLength(1000)
                .IsRequired(false);

            builder.Property(e => e.Merchandise)
                .HasColumnName("merchandise")
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(e => e.MerchandiseDescription)
                .HasColumnName("merchandise_description")
                .HasMaxLength(1000)
                .IsRequired(false);

            builder.Property(e => e.Category)
                .HasColumnName("category")
                .HasColumnType("merchandise_category_enum")
                .IsRequired(false);

            builder.Property(e => e.HasMerchandiseDescription)
                .HasColumnName("has_merchandise_description")
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasOne(e => e.Warehouse)
                .WithMany(w => w.AssignmentOperationals)
                .HasForeignKey(e => e.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(ao => ao.Status)
                .HasColumnName("status")
                .HasColumnType("assignment_operational_status_enum")
                .HasDefaultValueSql("'pending'::assignment_operational_status_enum")
                .IsRequired();

            builder.Property(ao => ao.HasMachineryAssigned)
                .HasColumnName("has_machinery_assigned")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(ao => ao.HasEnclosureAssigned)
                .HasColumnName("has_enclosure_assigned")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(ao => ao.HasCollaboratorsAssigned)
                .HasColumnName("has_collaborators_assigned")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(ao => ao.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(ao => ao.AdditionalData)
                .HasColumnName("additional_data")
                .HasColumnType("jsonb")
                .IsRequired(false);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(ao => ao.OperationalOrder)
                .WithMany(o => o.AssignmentOperationals)
                .HasForeignKey(ao => ao.OperationalOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(ao => ao.AssignmentsMachineries)
                .WithOne(am => am.AssignmentOperational)
                .HasForeignKey(am => am.AssignmentOperationalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(ao => ao.AssignmentCollaborators)
                .WithOne(ac => ac.AssignmentOperational)
                .HasForeignKey(ac => ac.AssignmentOperationalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(ao => ao.OperationalOrderId)
                .HasDatabaseName("ix_assignment_operational_operational_order_id");

            builder.HasIndex(ao => ao.Status)
                .HasDatabaseName("ix_assignment_operational_status");
        }
    }
}