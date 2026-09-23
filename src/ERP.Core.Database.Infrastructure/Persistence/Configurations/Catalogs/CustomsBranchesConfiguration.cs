using ERP.Core.Database.Domain.Entities.Catalogs;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class CustomBranchesConfiguration : IEntityTypeConfiguration<CustomsBranches>
{
    public void Configure(EntityTypeBuilder<CustomsBranches> builder)
    {
        builder.ToTable("customs_branches");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("custom_branch_id");
        
        builder.Property(e => e.CustomsBranchName)
            .HasColumnName("customs_branch_name")
            .IsRequired(false);

        builder.Property(e => e.Code)
            .HasColumnName("code")
            .IsRequired(false);

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