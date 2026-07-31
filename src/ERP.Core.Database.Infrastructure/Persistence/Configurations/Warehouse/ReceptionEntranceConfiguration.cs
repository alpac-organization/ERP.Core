using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
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

        builder.Property(e => e.Aduana)
            .HasColumnName("aduana")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(e => e.PlateNumber)
            .HasColumnName("plate_number")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(e => e.TrailerChassis)
            .HasColumnName("trailer_chassis")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.DriverLicense)
            .HasColumnName("driver_license")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(e => e.Transportista)
            .HasColumnName("transportista")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.DriverName)
            .HasColumnName("driver_name")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.SealNumber)
            .HasColumnName("seal_number")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.DocumentType)
            .HasColumnName("document_type")
            .HasColumnType("document_type_enum")
            .IsRequired();

        builder.Property(e => e.TransportUnitExitDate)
            .HasColumnName("transport_unit_exit_date")
            .HasColumnType("date")
            .IsRequired(false);

        builder.Property(e => e.TransportUnitExitTime)
            .HasColumnName("transport_unit_exit_time")
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

        builder.HasOne(e => e.TransportUnit)
            .WithMany()
            .HasForeignKey(e => e.TransportUnitId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.RecordEntrance)
            .WithOne(e => e.ReceptionEntrance)
            .HasForeignKey<ReceptionEntrance>(e => e.RecordEntranceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}