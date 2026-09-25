using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class SupplierPaymentMethodsConfiguration : IEntityTypeConfiguration<SupplierPaymentMethod>
    {
        public void Configure(EntityTypeBuilder<SupplierPaymentMethod> builder)
        {
            builder.ToTable("supplier_payment_methods");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("supplier_payment_method_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.SupplierId)
                .HasColumnName("supplier_id")
                .IsRequired();

            builder.Property(e => e.PaymentMethodType)
                .HasColumnName("payment_method_type")
                .HasColumnType("payment_method_type_enum")
                .IsRequired();

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(e => e.Notes)
                .HasColumnName("notes")
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(e => e.Supplier)
                .WithMany(s => s.SupplierPaymentMethods)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => e.SupplierId)
                .HasDatabaseName("ix_supplier_payment_methods_supplier_id");

            builder.HasIndex(e => new { e.SupplierId, e.PaymentMethodType })
                .HasDatabaseName("ix_supplier_payment_methods_supplier_payment_type")
                .IsUnique();
        }
    }
}