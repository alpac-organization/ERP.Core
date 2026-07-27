using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class QuotesConfiguration : IEntityTypeConfiguration<Quotation>
    {
        public void Configure(EntityTypeBuilder<Quotation> builder)
        {
            builder.ToTable("quotes");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("quotation_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.MadeBy)
                .HasColumnName("made_by")
                .IsRequired();

            builder.Property(e => e.BranchId)
                .HasColumnName("branch_id")
                .IsRequired();

            builder.Property(e => e.QuotationCode)
                .HasColumnName("quotation_code")
                .IsRequired();

            builder.Property(e => e.QuoteDate)
                .HasColumnName("quote_date")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.Observations)
                .HasColumnName("observations")
                .IsRequired(false);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasMany(p => p.QuoteDetails)
                .WithOne(p => p.Quotation)
                .HasForeignKey(p => p.QuotationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}