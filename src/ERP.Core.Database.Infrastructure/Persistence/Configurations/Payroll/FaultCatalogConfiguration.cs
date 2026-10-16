

using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
   public class FaultCatalogConfiguration : IEntityTypeConfiguration<FaultCatalog>
   {
      public void Configure(EntityTypeBuilder<FaultCatalog> builder)
      {
         builder.ToTable("fault_catalogs");

         builder.HasKey(e => e.Id);

         builder.Property(e => e.Id)
            .HasColumnName("fault_catalog_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

         builder.HasIndex(e => e.Id)
            .IsUnique()
            .HasDatabaseName("ix_fault_catalog_id");

         builder.Property(e => e.CompanyId)
            .HasColumnName("company_id")
            .IsRequired();

         builder.Property(e => e.Code)
            .HasColumnName("code")
            .HasMaxLength(50)
            .IsRequired();

         builder.Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(150)
            .IsRequired();

         builder.Property(e => e.Description)
            .HasColumnName("description")
            .HasMaxLength(500)
            .IsRequired();

         builder.Property(e => e.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();

         builder.Property(e => e.FaultSeverity)
            .HasColumnName("fault_severity")
            .HasColumnType("fault_severity_enum")
            .IsRequired();

         builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

         builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

         builder.HasIndex(e => new { e.CompanyId, e.Code })
            .IsUnique()
            .HasDatabaseName("ix_fault_catalogs_company_code");

         builder.HasOne(e => e.Company)
            .WithMany(c => c.FaultCatalogs)
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);
      }
   }
}