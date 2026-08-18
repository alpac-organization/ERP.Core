using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class ShippingCompanyConfiguration : IEntityTypeConfiguration<ShippingCompanies>
{
    public void Configure(EntityTypeBuilder<ShippingCompanies> builder)
    {
        builder.ToTable("shipping_companies");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("shipping_company_id");

        builder.Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasIndex(e => e.Name).IsUnique();
    }
}