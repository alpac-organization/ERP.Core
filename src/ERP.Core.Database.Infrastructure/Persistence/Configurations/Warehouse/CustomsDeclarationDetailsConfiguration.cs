using System.Security.Cryptography.X509Certificates;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class CustomsDeclarationDetailsCondiguration : IEntityTypeConfiguration<CustomsDeclarationDetails>
{
    public void Configure(EntityTypeBuilder<CustomsDeclarationDetails> builder)
    {
        builder.ToTable("customs_declaration_details");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("customs_declaration_detail_id");
        
        builder.Property(e => e.Packages)
            .HasColumnName("packages")
            .IsRequired();
 
        builder.Property(e => e.Customer)
            .HasColumnName("customer")
            .HasMaxLength(100)
            .IsRequired();
 
        builder.Property(e => e.Product)
            .HasColumnName("product")
            .HasMaxLength(100)
            .IsRequired();
 
        builder.Property(e => e.ContainerNumber)
            .HasColumnName("container_number")
            .HasMaxLength(20)
            .IsRequired();
 
        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();
 
        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(e => e.CustomsDeclarations)
            .WithOne(e => e.Details)
            .HasForeignKey<CustomsDeclarationDetails>(e => e.CustomsDeclarationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}