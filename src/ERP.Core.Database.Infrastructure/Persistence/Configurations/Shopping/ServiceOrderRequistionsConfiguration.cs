using ERP.Core.Database.Domain.Entities.Shopping;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class ServiceOrderRequistionsConfiguration : IEntityTypeConfiguration<ServiceOrderRequistions>
    {
        public void Configure(EntityTypeBuilder<ServiceOrderRequistions> builder)
        {
            builder.ToTable("service_order_requistions");

            builder.HasKey(so => so.Id);

            builder.Property(so => so.Id)
                .HasColumnName("services_order_requisition_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(so => so.ServiceOrderId)
                .HasColumnName("service_order_id")
                .IsRequired();

            builder.Property(so => so.CreatedByUserId)
                .HasColumnName("created_by_user_id")
                .IsRequired();

            builder.Property(so => so.Concept)
                .HasColumnName("concept")
                .IsRequired();

            builder.Property(so => so.Status)
                .HasColumnName("status")
                .HasColumnType("service_order_requisition_status_enum")
                .HasDefaultValueSql("'pending'::service_order_requisition_status_enum")
                .IsRequired();

            builder.Property(so => so.CreatedByUserId)
                .HasColumnName("created_by_user_id")
                .IsRequired();


            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            //Relaciones de las tablas
            builder.HasOne(so => so.ServicesOrder)
                .WithMany(os => os.ServiceOrderRequistions)
                .HasForeignKey(so => so.ServiceOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(so => so.User)
                .WithMany(os => os.ServiceOrderRequistions)
                .HasForeignKey(so => so.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            //Indices de busqueda.
            builder.HasIndex(so => so.SoRequitionCode)
                .HasDatabaseName("ix_services_orders_requisition_code")
                .IsUnique();

            builder.HasIndex(so => so.ServiceOrderId)
                .HasDatabaseName("ix_services_order_service_id_");
        }
    }
}
