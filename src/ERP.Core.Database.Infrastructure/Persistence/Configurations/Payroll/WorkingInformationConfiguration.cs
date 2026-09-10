using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class WorkingInformatinConfiguration : IEntityTypeConfiguration<WorkingInformation>
    {
        public void Configure(EntityTypeBuilder<WorkingInformation> builder)
        {
            builder.ToTable("working_information");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("working_information_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();
                
            builder.Property(e => e.WorkPhoneNumber)
                .HasColumnName("work_phone_number")
                .IsRequired(false);

            builder.Property(e => e.WorkEmail)
                .HasColumnName("work_email")
                .IsRequired(false);

            builder.Property(e => e.InssNumber)
                .HasColumnName("inss_number")
                .IsRequired(false);

            builder.Property(e => e.Daem)
                .HasColumnName("daem")
                .IsRequired(false);

            builder.Property(e => e.BankAccountNumber)
                .HasColumnName("bank_account_number")
                .IsRequired(false);
        
            //Nuevas relaciones aqui
            builder.Property(e => e.AreaId)
                .HasColumnName("area_id")
                .IsRequired();

            builder.Property(e => e.BranchId)
                .HasColumnName("branch_id")
                .IsRequired();

            builder.Property(e => e.JobPositionId)
                .HasColumnName("job_position_id")
                .IsRequired();

            builder.Property(e => e.CostCenterId)
                .HasColumnName("cost_center_id")
                .IsRequired(false);

            builder.Property(e => e.CollaboratorId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.Property(e => e.EntryDate)
                .HasColumnName("entry_date")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.DepartureDate)
                .HasColumnName("departure_date")
                .IsRequired(false);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");
       
            builder.HasOne(p => p.Collaborator)
                .WithOne(c => c.WorkingInformation)
                .HasForeignKey<WorkingInformation>(p => p.CollaboratorId) 
                .OnDelete(DeleteBehavior.Restrict);
                
            builder.HasOne(d => d.Branch)
                .WithMany(d => d.WorkingInformations)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.CostCenter)
                .WithMany(d => d.WorkingInformations)
                .HasForeignKey(d => d.CostCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Area)
                .WithMany(d => d.WorkingInformations)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.JobPosition)
                .WithMany(d => d.WorkingInformations)
                .HasForeignKey(d => d.JobPositionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.CollaboratorId)
                .IsUnique();
        }
    }
}