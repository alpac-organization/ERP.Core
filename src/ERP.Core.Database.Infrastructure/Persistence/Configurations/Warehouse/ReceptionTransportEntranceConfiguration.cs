using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class ReceptionTransportEntranceConfiguration : IEntityTypeConfiguration<ReceptionTransportEntrance>
{
    public void Configure(EntityTypeBuilder<ReceptionTransportEntrance> builder)
    {
        builder.ToTable("reception_transport_entrance");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("reception_transport_entrance_id");

        builder.Property(e => e.VehiclePlateNumber)
            .HasColumnName("vehicle_plate_number")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(e => e.VehicleChassisNumber)
            .HasColumnName("vehicle_chassis_number")
            .HasMaxLength(30)
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

        builder.HasOne(c => c.ReceptionEntrance)
                .WithOne(s => s.ReceptionTransport)
                .HasForeignKey<ReceptionTransportEntrance>(s => s.ReceptionEntranceId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}