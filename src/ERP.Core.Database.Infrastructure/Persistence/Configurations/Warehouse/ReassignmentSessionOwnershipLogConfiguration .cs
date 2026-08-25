using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class ReassignmentSessionOwnershipLogConfiguration : IEntityTypeConfiguration<ReassignmentSessionOwnershipLog>
{
    public void Configure(EntityTypeBuilder<ReassignmentSessionOwnershipLog> builder)
    {
        builder.ToTable("reassignment_session_ownership_log");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("reassignment_session_ownership_log_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.ReassignmentSessionId)
            .HasColumnName("reassignment_session_id")
            .IsRequired();

        builder.Property(e => e.UserId)
            .HasColumnName("user_id")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.StartedAtDate)
            .HasColumnName("started_at_date")
            .HasColumnType("date")
            .IsRequired();

        builder.Property(e => e.StartedAtTime)
            .HasColumnName("started_at_time")
            .IsRequired();

        builder.Property(e => e.EndedAtDate)
            .HasColumnName("ended_at_date")
            .HasColumnType("date")
            .IsRequired(false);

        builder.Property(e => e.EndedAtTime)
            .HasColumnName("ended_at_time")
            .IsRequired(false);

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(e => e.Session)
            .WithMany(s => s.OwnershipLog)
            .HasForeignKey(e => e.ReassignmentSessionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.ReassignmentSessionId)
            .HasDatabaseName("ix_reassignment_session_ownership_log_session_id");
    }
}