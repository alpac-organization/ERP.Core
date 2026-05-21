using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs
{
    public class TypesSubsidyConfiguration : IEntityTypeConfiguration<TypesSubsidy>
    {
        public void Configure(EntityTypeBuilder<TypesSubsidy> builder)
        {
            builder.ToTable("types_subsidy");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("type_subsidy_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.SubsidyName)
                .HasColumnName("subsidy_name")
                .IsRequired();

            builder.Property(e => e.Code)
                .HasColumnName("subsidy_code")
                .IsRequired(false);

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired();

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");
        }
    }
}