using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class SuppliersDetailsConfiguration : IEntityTypeConfiguration<SupplierDetails>
    {
        public void Configure(EntityTypeBuilder<SupplierDetails> builder)
        {
            builder.ToTable("suppliers_details");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("supplier_detail_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Address)
                .HasColumnName("address")
                .IsRequired(false);

            builder.Property(e => e.ContactName)
                .HasColumnName("contact_name")
                .IsRequired(false);

            builder.Property(e => e.ContactEmail)
                .HasColumnName("contact_email")
                .IsRequired(false);

            builder.Property(e => e.ContactPhoneNumber)
                .HasColumnName("contact_phone_number")
                .IsRequired(false);

            builder.Property(e => e.EmailSupport)
                .HasColumnName("email_support")
                .IsRequired(false);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at"); 

            builder.HasOne(p => p.Supplier)
                .WithOne(c => c.SupplierDetails)
                .HasForeignKey<SupplierDetails>(p => p.SupplierId) 
                .OnDelete(DeleteBehavior.Restrict);        
        }
    }
}