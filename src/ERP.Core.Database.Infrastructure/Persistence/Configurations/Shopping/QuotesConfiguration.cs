using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class QuotesConfiguration : IEntityTypeConfiguration<Quotation>
    {
        public void Configure(EntityTypeBuilder<Quotation> builder)
        {
            builder.ToTable("quotation");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("quotation_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.MadeBy)
                .HasColumnName("made_by")
                .IsRequired();

            builder.Property(e => e.ApproximateCostTotal)
                .HasColumnName("approximate_cost_total")
                .HasPrecision(18, 0)
                .IsRequired();

            builder.Property(e => e.Observations)
                .HasColumnName("observations")
                .IsRequired(false);

            // builder.Property(e => e.ConstitutionType)
            //     .HasColumnName("constitution_type")
            //     .HasColumnType("constitution_type_enum")
            //     .IsRequired();

            // builder.Property(e => e.IdentificationType)
            //     .HasColumnName("identification_type")
            //     .HasColumnType("identification_type_enum")
            //     .IsRequired();

            // builder.Property(e => e.Address)
            //     .HasColumnName("address")
            //     .IsRequired(false);

            // builder.Property(e => e.ContactName)
            //     .HasColumnName("contact_name")
            //     .IsRequired(false);

            // builder.Property(e => e.ContactEmail)
            //     .HasColumnName("contact_email")
            //     .IsRequired(false);

            // builder.Property(e => e.ContactPhoneNumber)
            //     .HasColumnName("contact_phone_number")
            //     .IsRequired(false);

            // builder.Property(e => e.EmailSupport)
            //     .HasColumnName("email_support")
            //     .IsRequired(false);

            // builder.Property(e => e.RegisterBy)
            //     .HasColumnName("register_by")
            //     .IsRequired();

            // builder.Property(e => e.IsActive)
            //     .HasColumnName("is_active")
            //     .HasDefaultValue(true)
            //     .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");
        }
    }
}