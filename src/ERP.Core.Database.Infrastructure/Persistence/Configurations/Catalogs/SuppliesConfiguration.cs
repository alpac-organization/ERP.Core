using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class SuppliesConfiguration : IEntityTypeConfiguration<Supplies>
{
    public void Configure(EntityTypeBuilder<Supplies> builder)
    {
        builder.ToTable("supplies");
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id)
            .HasColumnName("supplies_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasMaxLength(500);

        builder.Property(x => x.IsActive)
            .HasColumnName("is_active");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.DeletedAt)
            .HasColumnName("deleted_at");
    }
}