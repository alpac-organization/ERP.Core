using ERP.Core.Database.Domain.Entities.Operations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Operations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("invoices");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasColumnName("invoice_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();
            
            builder.Property(i => i.Status)
                .HasColumnName("status")
                .HasColumnType("invoice_status_enum")
                .HasDefaultValueSql("'pending'::invoice_status_enum")
                .IsRequired();

            builder.Property(i => i.InvoiceCode)
                .HasColumnName("invoice_code")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(i => i.Discount)
                .HasColumnName("discount")
                .HasPrecision(18, 2)
                .IsRequired(false);

            builder.Property(i => i.DiscountPercentage)
                .HasColumnName("discount_percentage")
                .HasPrecision(5, 2)
                .IsRequired(false);

            builder.Property(i => i.TotalAmount)
                .HasColumnName("total_amount")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(i => i.DueDate)
                .HasColumnName("due_date")
                .IsRequired(false);

            builder.Property(i => i.DateIssued)
                .HasColumnName("date_issued")
                .IsRequired(false);

            builder.Property(i => i.OperationalOrderId)
                .HasColumnName("operational_order_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(i => i.OperationalOrder)
                .WithMany()
                .HasForeignKey(i => i.OperationalOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(i => i.InvoiceCode)
                .HasDatabaseName("ix_invoices_invoice_code")
                .IsUnique();

            builder.HasIndex(i => i.OperationalOrderId)
                .HasDatabaseName("ix_invoices_operational_order_id");
        }
    }
}