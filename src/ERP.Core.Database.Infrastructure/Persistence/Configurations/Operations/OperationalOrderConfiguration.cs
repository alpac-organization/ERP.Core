using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Operations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Operations
{
    public class OperationalOrderConfiguration : IEntityTypeConfiguration<OperationalOrder>
    {
        public void Configure(EntityTypeBuilder<OperationalOrder> builder)
        {
            builder.ToTable("operational_orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasColumnName("operational_order_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(o => o.OpCode)
                .HasColumnName("op_code")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(o => o.Description)
                .HasColumnName("description")
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(o => o.Status)
                .HasColumnName("status")
                .HasColumnType("operational_order_status_enum")
                .HasDefaultValueSql("'in_progress'::operational_order_status_enum")
                .IsRequired();

            builder.Property(o => o.CostCenterId)
                .HasColumnName("cost_center_id")
                .IsRequired();

            builder.Property(o => o.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired(false);

            builder.Property(o => o.DocumentNumber)
                .HasColumnName("document_number")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(o => o.PackagesCount)
                .HasColumnName("packages_count")
                .IsRequired(false);

            builder.Property(o => o.Weight)
                .HasColumnName("weight")
                .HasPrecision(8,2)
                .IsRequired(false);

            builder.Property(o => o.ReceptionId)
                .HasColumnName("reception_id")
                .IsRequired(false);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(o => o.CostCenter)
                .WithMany()
                .HasForeignKey(o => o.CostCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Customer)
                .WithMany(c => c.OperationalOrders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Reception)
                .WithMany(r => r.OperationalOrders)
                .HasForeignKey(o => o.ReceptionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(o => o.ServicesOrders)
                .WithOne(so => so.OperationalOrder)
                .HasForeignKey(so => so.OperationalOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(o => o.OpCode)
                .HasDatabaseName("ix_operational_orders_op_code")
                .IsUnique();

            builder.HasIndex(o => o.CustomerId)
                .HasDatabaseName("ix_operational_orders_customer_id");

            builder.HasIndex(o => o.CostCenterId)
                .HasDatabaseName("ix_operational_orders_cost_center_id");

            builder.HasIndex(o => o.DocumentNumber)
                .HasDatabaseName("ix_operational_orders_duca_number");

            builder.HasIndex(o => o.ReceptionId)
                .HasDatabaseName("ix_operational_orders_reception_id");
        }
    }
}