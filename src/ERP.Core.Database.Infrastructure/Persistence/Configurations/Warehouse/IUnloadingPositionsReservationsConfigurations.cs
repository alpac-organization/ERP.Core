using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class UnloadingPositionReservationsConfiguration : IEntityTypeConfiguration<UnloadingPositionReservations>
{
    public void Configure(EntityTypeBuilder<UnloadingPositionReservations> builder)
    {
        builder.ToTable("unloading_position_reservations");
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id)
            .HasColumnName("unloading_position_reservations_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.EntranceDucatId)
            .HasColumnName("entrance_ducat_id")
            .IsRequired();

        builder.Property(x => x.WarehouseAssignmentId)
            .HasColumnName("warehouse_assignment_id")
            .IsRequired();

        builder.Property(x => x.WarehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();

        builder.Property(x => x.UnloadingDetailsId)
            .HasColumnName("unloading_details_id")
            .IsRequired(false);

        builder.Property(x => x.RackPositionId)
            .HasColumnName("rack_position_id")
            .IsRequired(false);

        builder.Property(x => x.LotPositionId)
            .HasColumnName("lot_position_id")
            .IsRequired(false);

        builder.Property(x => x.Quantity)
            .HasColumnName("quantity")
            .IsRequired();

        builder.Property(x => x.ReservedByUserId)
            .HasColumnName("reserved_by_user_id")
            .IsRequired();

        builder.Property(x => x.ReservedAtDate)
            .HasColumnName("reserved_at_date")
            .IsRequired();

        builder.Property(x => x.ReservedAtTime)
            .HasColumnName("reserved_at_time")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(x => x.WarehouseAssignment)
            .WithMany()
            .HasForeignKey(x => x.WarehouseAssignmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}