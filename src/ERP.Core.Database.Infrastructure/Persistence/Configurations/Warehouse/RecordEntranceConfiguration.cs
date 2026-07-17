using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class RecordEntranceConfiguration : IEntityTypeConfiguration<RecordEntrance>
{
    public void Configure(EntityTypeBuilder<RecordEntrance> builder)
    {
        builder.ToTable("record_entrances");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("record_entrance_id")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(e => e.ServiceOrderId)
            .HasColumnName("service_order_id")
            .IsRequired(false);

        builder.Property(e => e.CurrentStepCode)
            .HasColumnName("current_step_code")
            .IsRequired();

        builder.Property(e => e.Status)
            .HasColumnName("status")
            .HasColumnType("record_entrance_status_enum")
            .IsRequired();

        builder.Property(e => e.ClosedAtDate)
            .HasColumnName("closed_at_date")
            .IsRequired(false);

        builder.Property(e => e.ClosedAtTime)
            .HasColumnName("closed_at_time")
            .IsRequired(false);

        builder.Property(e => e.IsConsolidated)
            .HasColumnName("is_consolidated")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        //Relaciones 1:1 y 1:N
        builder.HasOne(e => e.CurrentStep)
            .WithMany(d => d.RecordEntrances)
            .HasForeignKey(d => d.CurrentStepCode)
            .HasPrincipalKey(d => d.Code)
            .OnDelete(DeleteBehavior.Restrict);

    }
}