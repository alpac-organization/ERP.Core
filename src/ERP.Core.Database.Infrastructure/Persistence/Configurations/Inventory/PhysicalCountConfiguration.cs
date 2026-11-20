using ERP.Core.Database.Domain.Entities.Inventory;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Inventory
{
    public class PhysicalCountConfiguration : IEntityTypeConfiguration<PhysicalCount>
    {
        public void Configure(EntityTypeBuilder<PhysicalCount> builder)
        {
            builder.ToTable("physical_counts");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("physical_count_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.CompanyId)
                .HasColumnName("company_id")
                .IsRequired();

            builder.Property(e => e.BranchId)
                .HasColumnName("branch_id")
                .IsRequired();

            builder.Property(e => e.AreaId)
                .HasColumnName("area_id")
                .IsRequired(false);

            builder.Property(e => e.CostCenterId)
                .HasColumnName("cost_center_id")
                .IsRequired(false);

            builder.Property(e => e.CategoryId)
                .HasColumnName("category_id")
                .IsRequired(false);

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("physical_count_status_enum")
                .HasDefaultValueSql("'draft'::physical_count_status_enum")
                .IsRequired();

            builder.Property(e => e.Notes)
                .HasColumnName("notes")
                .IsRequired(false);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedBy)
                .HasColumnName("created_by")
                .IsRequired();

            builder.Property(e => e.CompletedAt)
                .HasColumnName("completed_at")
                .IsRequired(false);

            builder.Property(e => e.CompletedBy)
                .HasColumnName("completed_by")
                .IsRequired(false);

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            #region Relations
            builder.HasOne(e => e.Company)
                .WithMany(e => e.PhysicalCounts)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Branch)
                .WithMany(e => e.PhysicalCounts)
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Area)
                .WithMany(e => e.PhysicalCounts)
                .HasForeignKey(e => e.AreaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.CostCenter)
                .WithMany(e => e.PhysicalCounts)
                .HasForeignKey(e => e.CostCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Category)
                .WithMany(e => e.PhysicalCounts)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion Relations

            builder.HasIndex(e => new { e.CompanyId, e.BranchId })
                .HasDatabaseName("ix_physical_counts_company_branch");
        }
    }
}