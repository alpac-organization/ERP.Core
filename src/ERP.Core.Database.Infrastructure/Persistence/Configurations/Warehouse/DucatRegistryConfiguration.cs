using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class DucatRegistryConfiguration : IEntityTypeConfiguration<DucatRegistry>
{
    public void Configure(EntityTypeBuilder<DucatRegistry> builder)
    {
        builder.ToTable("ducat_registry");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
          .HasColumnName("ducat_registtry_id");

        builder.Property(e => e.RecordEntranceId)
            .HasColumnName("record_entrance_id")
            .IsRequired();

        builder.Property(e => e.ShippingCompanyId)
            .HasColumnName("shipping_company_id")
            .IsRequired();

        builder.Property(e => e.GeneralObservations)
            .HasColumnName("general_observations")
            .HasMaxLength(1000)
            .IsRequired(false);

        builder.Property(e => e.IsInTransit)
            .HasColumnName("is_in_transit")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.Property(e => e.UpdatedDate)
            .HasColumnName("updated_date")
            .HasColumnType("date")
            .IsRequired(false);

        builder.Property(e => e.UpdatedTime)
            .HasColumnName("updated_time")
            .IsRequired(false);

        builder.Property(e => e.UpdatedByUserId)
            .HasColumnName("updated_by_user_id")
            .HasMaxLength(450)
            .IsRequired(false);

        builder.Property(e => e.UpdatedByUserName)
            .HasColumnName("updated_by_user_name")
            .HasMaxLength(450)
            .IsRequired(false);

        builder.Property(e => e.RegisteredStartDate)
            .HasColumnName("registered_start_date")
            .HasColumnType("date")
            .IsRequired(false);

        builder.Property(e => e.RegisteredEndDate)
            .HasColumnName("registered_end_date")
            .HasColumnType("date")
            .IsRequired(false);

        builder.Property(e => e.RegisteredStartTime)
            .HasColumnName("registered_start_time")
            .IsRequired(false);

        builder.Property(e => e.RegisteredEndTime)
            .HasColumnName("registered_end_time")
            .IsRequired(false);

        builder.Property(e => e.Status)
            .HasColumnName("status")
            .HasColumnType("duca_status_enum")
            .HasDefaultValue(DucaStatus.Pending);

        builder.Property(e => e.RegisteredByUserId)
            .HasColumnName("registered_by_user_id")
            .HasMaxLength(450)
            .IsRequired(false);

        builder.Property(e => e.RegisteredByUserName)
            .HasColumnName("registered_by_user_name")
            .HasMaxLength(450)
            .IsRequired(false);


        // Relación 1:1 con la entrada principal
        builder.HasOne(e => e.RecordEntrance)
            .WithOne(r => r.DucatRegistry)
            .HasForeignKey<DucatRegistry>(e => e.RecordEntranceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ShippingCompany)
            .WithMany()
            .HasForeignKey(e => e.ShippingCompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.ShippingCompanyId);
    }
}
