using ERP.Core.Database.Domain.Entities.Operations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Operations
{
    public class OperationalServiceConfiguration : IEntityTypeConfiguration<OperationalService>
    {
        public void Configure(EntityTypeBuilder<OperationalService> builder)
        {
            builder.ToTable("operational_services");

            builder.HasKey(os => os.Id);

            builder.Property(os => os.Id)
                .HasColumnName("operational_service_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(os => os.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(os => os.ServiceCode)
                .HasColumnName("service_code")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(os => os.ServiceName)
                .HasColumnName("service_name")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(os => os.Description)
                .HasColumnName("description")
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasMany(os => os.ServicesOrders)
                .WithOne(so => so.OperationalService)
                .HasForeignKey(so => so.OperationalServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(os => os.ServiceCode)
                .HasDatabaseName("ix_operational_services_service_code")
                .IsUnique();
        }
    }
}