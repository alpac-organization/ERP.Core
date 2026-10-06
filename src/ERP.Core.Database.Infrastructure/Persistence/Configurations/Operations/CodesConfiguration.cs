using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Operations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Operations;

public class CodesConfiguration : IEntityTypeConfiguration<Codes>
{
    public void Configure(EntityTypeBuilder<Codes> builder)
    {
        builder.ToTable("codes");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.AssignmentId)
            .IsRequired();

        builder.Property(c => c.CodeType)
            .HasColumnName("code_type")
            .HasColumnType("codes_type_enum")
            .IsRequired();

        builder.Property(c => c.ImageUrl)
            .HasColumnName("image_url")
            .IsRequired();

        builder.Property(c => c.CodeGenerated)
            .HasColumnName("code_generated")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(c => c.Assignment)
            .WithMany()
            .HasForeignKey(c => c.AssignmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}