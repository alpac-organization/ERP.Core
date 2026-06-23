using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Infrastructure.Persistence.Context
{
    public class ErpDbContext(DbContextOptions<ErpDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Module> Modules => Set<Module>();
        public DbSet<UserProfile> Profiles => Set<UserProfile>();
        public DbSet<Session> Sessions => Set<Session>();
        public DbSet<UserModuleRoles> ModulesWithRoles => Set<UserModuleRoles>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserModuleRoles> UserModuleRoles => Set<UserModuleRoles>();

        #region MOD:Nomina
        public DbSet<Salary> Salaries => Set<Salary>();
        public DbSet<Vacation> Vacations => Set<Vacation>();
        public DbSet<Collaborator> Collaborators => Set<Collaborator>();
        public DbSet<PermitApplication> PermitApplications => Set<PermitApplication>();
        public DbSet<WorkingInformation> WorkingInformation => Set<WorkingInformation>();
        public DbSet<PersonalInformation> PersonalInformations => Set<PersonalInformation>();
        public DbSet<WorkPositionHistory> WorkPositionHistories => Set<WorkPositionHistory>();
        public DbSet<AssignedTravelExpenses> AssignedTravelExpenses => Set<AssignedTravelExpenses>();
        public DbSet<PermitApplicationPending> PermitApplicationsPending => Set<PermitApplicationPending>();
        #endregion

        #region MOD:Nomina:Reportes
        public DbSet<VacationAccrual> VacationAccruals => Set<VacationAccrual>();
        public DbSet<IncomeTaxAccrual> IncomeTaxAccruals => Set<IncomeTaxAccrual>();
        public DbSet<ChristmasBonusAccrual> ChristmasBonusAccruals => Set<ChristmasBonusAccrual>();
        public DbSet<InssAccountingInformation> InssAccountingInformation => Set<InssAccountingInformation>();
        public DbSet<RecordsTravelExpensePayments> RecordsTravelExpensePayments => Set<RecordsTravelExpensePayments>();
        #endregion

        #region MOD:Nomina:Ingreso y deducciones
        public DbSet<Income> Incomes => Set<Income>();
        public DbSet<Subsidy> Subsidies => Set<Subsidy>();
        public DbSet<Deduction> Deductions => Set<Deduction>();
        public DbSet<DeductionPaymentHistory> DeductionPaymentHistories => Set<DeductionPaymentHistory>();
        #endregion

        public DbSet<Catalog> Catalogs => Set<Catalog>();
        public DbSet<SubCatalog> SubCatalogs => Set<SubCatalog>();

        public DbSet<Payroll> Payrolls => Set<Payroll>();
        public DbSet<OrdinaryPayroll> OrdinaryPayrolls => Set<OrdinaryPayroll>();
        public DbSet<AssistanceControl> AssistanceControls => Set<AssistanceControl>();
        public DbSet<ProfessionalServicesPayroll> ProfessionalServicesPayrolls => Set<ProfessionalServicesPayroll>();
        
        #region Catologos
        public DbSet<Branch> Branches => Set<Branch>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Holidays> Holidays => Set<Holidays>();
        public DbSet<WorkArea> WorkAreas => Set<WorkArea>();
        public DbSet<CostCenter> CostCenters => Set<CostCenter>();
        public DbSet<JobPosition> JobPositions => Set<JobPosition>();
        public DbSet<TypesIncome> TypesIncomes => Set<TypesIncome>();
        public DbSet<TypesSubsidy> TypesSubsidies => Set<TypesSubsidy>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<TypesAccountingPayroll> TypesAccountingPayrolls => Set<TypesAccountingPayroll>();
        #endregion

        #region MOD: Bodegas y Clientes
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<CustomerType> CustomersTypes => Set<CustomerType>();
        public DbSet<CategoryProducts> CategoryProducts => Set<CategoryProducts>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Warehouses> Warehouses => Set<Warehouses>();
        #endregion
                
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.HasPostgresEnum<CatalogType>("public", "catalog_type_enum");
            modelBuilder.HasPostgresEnum<RoleType>("public", "role_type_enum");
            modelBuilder.HasPostgresEnum<PermissionType>("public", "permission_type_enum");
            modelBuilder.HasPostgresEnum<UserType>("public", "user_type_enum");
            modelBuilder.HasPostgresEnum<UserStatus>("public", "user_status_enum");
            modelBuilder.HasPostgresEnum<GenderType>("public", "gender_type_enum");
            modelBuilder.HasPostgresEnum<IdentificationType>("public", "identification_type_enum");
            modelBuilder.HasPostgresEnum<CollaboratorStatus>("public", "collaborator_status_enum");
            modelBuilder.HasPostgresEnum<SalaryType>("public", "salary_type_enum");
            modelBuilder.HasPostgresEnum<Currency>("public", "currency_enum");
            modelBuilder.HasPostgresEnum<MaritalStatus>("public", "marital_status_enum");
            modelBuilder.HasPostgresEnum<PermitApplicationStatus>("public", "permit_application_status_enum");
            modelBuilder.HasPostgresEnum<PermitApplicationType>("public", "permit_application_type_enum");
            modelBuilder.HasPostgresEnum<DeductionType>("public", "deduction_type_enum");
            modelBuilder.HasPostgresEnum<PayrollStatus>("public", "payroll_status_enum");
            modelBuilder.HasPostgresEnum<PayrollType>("public", "payroll_type_enum");
            modelBuilder.HasPostgresEnum<TaxType>("public", "tax_type_enum");
            modelBuilder.HasPostgresEnum<SourceDeductionPayment>("public", "source_deduction_payment_enum");
            modelBuilder.HasPostgresEnum<DeductionStatus>("public","deduction_status_enum");
            modelBuilder.HasPostgresEnum<DeductionPaymentStatus>("public","deduction_payment_status");
            modelBuilder.HasPostgresEnum<PayrollPeriod>("public","payroll_period_enum");

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?));

                foreach (var property in properties)
                {
                    property.SetValueConverter(new Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<DateTime, DateTime>(
                        v => v.Kind == DateTimeKind.Utc ? v : DateTime.SpecifyKind(v, DateTimeKind.Utc),
                        v => v.Kind == DateTimeKind.Utc ? v : DateTime.SpecifyKind(v, DateTimeKind.Utc)
                    ));
                }
            }

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    var type = Nullable.GetUnderlyingType(property.ClrType) ?? property.ClrType;
                }
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ErpDbContext).Assembly);
        }
    }
}