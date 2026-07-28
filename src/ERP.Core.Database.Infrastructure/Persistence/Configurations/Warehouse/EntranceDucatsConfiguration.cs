using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class EntranceDucatsConfiguration : IEntityTypeConfiguration<EntranceDucats>
{
    public void Configure(EntityTypeBuilder<EntranceDucats> builder)
    {
        builder.ToTable("entrance_ducats");
        
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("entrance_ducat_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(e => e.RecordEntranceId)
            .HasColumnName("record_entrance_id")
            .IsRequired();
        
        builder.Property(e => e.DucatNumber)
            .HasColumnName("ducat_number")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasColumnName("status")
            .HasColumnType("duca_status_enum")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");


        builder.HasOne(e => e.RecordEntrance)
            .WithMany(h => h.EntranceDucats)
            .HasForeignKey(e => e.RecordEntranceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}