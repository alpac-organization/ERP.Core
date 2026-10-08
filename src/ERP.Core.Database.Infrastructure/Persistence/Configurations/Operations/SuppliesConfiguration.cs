// using ERP.Core.Database.Domain.Entities.Operations;

// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;

// namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Operations
// {
//     public class SuppliesConfiguration : IEntityTypeConfiguration<Supplies>
//     {
//         public void Configure(EntityTypeBuilder<Supplies> builder)
//         {
//             builder.ToTable("supplies");

//             builder.HasKey(i => i.Id);

//             builder.Property(i => i.Id)
//                 .HasColumnName("supply_id")
//                 .HasDefaultValueSql("gen_random_uuid()")
//                 .ValueGeneratedOnAdd()
//                 .IsRequired();

//             builder.Property(i => i.Code)
//                 .HasColumnName("code")
//                 .HasMaxLength(50)
//                 .IsRequired();

//             builder.Property(i => i.Description)
//                 .HasColumnName("description")
//                 .HasMaxLength(500)
//                 .IsRequired(false);

//             builder.Property(i => i.UnitMeasure)
//                 .HasColumnName("unit_measure")
//                 .HasColumnType("unit_measure_enum")
//                 .HasDefaultValueSql("'none'::unit_measure_enum")
//                 .IsRequired();

//             builder.Property(i => i.Category)
//                 .HasColumnName("category")
//                 .HasColumnType("supply_category_enum")
//                 .HasDefaultValueSql("'none'::supply_category_enum")
//                 .IsRequired();

//             builder.Property(i => i.Stock)
//                 .HasColumnName("stock")
//                 .HasPrecision(12, 2)
//                 .IsRequired();

//             builder.Property(i => i.IsActive)
//                 .HasColumnName("is_active")
//                 .HasDefaultValue(true)
//                 .IsRequired();

//             builder.Property(e => e.CreatedAt)
//                 .HasColumnName("created_at")
//                 .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                 .ValueGeneratedOnAdd();

//             builder.Property(e => e.DeletedAt)
//                 .HasColumnName("deleted_at");
//         }
//     }
// }