using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class ReceptionEntranceConfiguration : IEntityTypeConfiguration<ReceptionEntrance>
{
    public void Configure(EntityTypeBuilder<ReceptionEntrance> builder)
    {
        builder.ToTable("reception_entrance");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
           .HasColumnName("reception_entrance_id");

        builder.Property(e => e.RecordEntranceId)
            .HasColumnName("record_entrance_id")
            .IsRequired();

        builder.Property(e => e.CountryOfOrigin)
            .HasColumnName("country_of_origin")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.VehiclePlateNumber)
            .HasColumnName("vehicle_plate_number")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(e => e.VehicleChassisNumber)
            .HasColumnName("vehicle_chassis_number")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(e => e.ContainerNumber)
            .HasColumnName("container_number")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.DriverLicense)
            .HasColumnName("driver_license")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.Transportista)
            .HasColumnName("transportista")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.DriverName)
            .HasColumnName("driver_name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.SealNumber)
            .HasColumnName("seal_number")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.EvidenceUrls)
            .HasColumnName("evidence_urls")
            .HasColumnType("text[]")
            .IsRequired(false);

        builder.Property(e => e.DeletedEvidenceUrls)
            .HasColumnName("deleted_evidence_urls")
            .HasColumnType("text[]")
            .IsRequired(false);

        builder.Property(e => e.DocumentType)
            .HasColumnName("document_type")
            .HasColumnType("document_type_enum")
            .IsRequired();

        builder.Property(e => e.TransportUnit)
            .HasColumnName("transport_unit")
            .HasColumnType("transport_unit_enum")
            .IsRequired();

        builder.Property(e => e.VehicleExitDate)
            .HasColumnName("vehicle_exit_date")
            .HasColumnType("date")
            .IsRequired(false);

        builder.Property(e => e.VehicleExitTime)
            .HasColumnName("vehicle_exit_time")
            .IsRequired(false);

        builder.Property(e => e.ContainerExitDate)
            .HasColumnName("container_exit_date")
            .HasColumnType("date")
            .IsRequired(false);

        builder.Property(e => e.ContainerExitTime)
            .HasColumnName("container_exit_time")
            .IsRequired(false);

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

        builder.HasOne(e => e.CustomsBranches)
            .WithMany()
            .HasForeignKey(e => e.CustomBranchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.RecordEntrance)
            .WithOne(e => e.ReceptionEntrance)
            .HasForeignKey<ReceptionEntrance>(e => e.RecordEntranceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}