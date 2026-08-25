using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Context
{
    public class ErpDbContext(DbContextOptions<ErpDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Device> Devices => Set<Device>();
        public DbSet<Module> Modules => Set<Module>();
        public DbSet<Session> Sessions => Set<Session>();
        public DbSet<UserProfile> Profiles => Set<UserProfile>();
        public DbSet<Notification> Notifications => Set<Notification>();
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
        public DbSet<CustomsBranches> CustomsBranches => Set<CustomsBranches>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Holidays> Holidays => Set<Holidays>();
        public DbSet<WorkArea> WorkAreas => Set<WorkArea>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<CostCenter> CostCenters => Set<CostCenter>();
        public DbSet<JobPosition> JobPositions => Set<JobPosition>();
        public DbSet<TypesIncome> TypesIncomes => Set<TypesIncome>();
        public DbSet<TypesSubsidy> TypesSubsidies => Set<TypesSubsidy>();
        public DbSet<UnitMeasure> UnitsMeasurement => Set<UnitMeasure>();
        public DbSet<TypesAccountingPayroll> TypesAccountingPayrolls => Set<TypesAccountingPayroll>();
        public DbSet<ShippingCompanies> ShippingCompanies => Set<ShippingCompanies>();
        public DbSet<SectionCapacity> SectionCapacities => Set<SectionCapacity>();
        #endregion

        #region Bodegas y Clientes
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<CustomerType> CustomersTypes => Set<CustomerType>();
        public DbSet<CategoryProducts> CategoryProducts => Set<CategoryProducts>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Warehouses> Warehouses => Set<Warehouses>();
        public DbSet<WarehouseDetails> WarehouseDetails => Set<WarehouseDetails>();
        public DbSet<WarehouseCapacity> WarehouseCapacities => Set<WarehouseCapacity>();
        public DbSet<OutsourcedWarehouse> OutsourcedWarehouses => Set<OutsourcedWarehouse>();
        public DbSet<ServiceOrder> ServiceOrders => Set<ServiceOrder>();
        public DbSet<WorkflowStepDefinition> WorkflowStepDefinitions => Set<WorkflowStepDefinition>();
        public DbSet<Sections> Sections => Set<Sections>();
        public DbSet<SectionOverflowCapacity> SectionOverflowCapacities => Set<SectionOverflowCapacity>();
        public DbSet<Racks> Racks => Set<Racks>();
        public DbSet<RackPositions> RackPositions => Set<RackPositions>();
        public DbSet<Lots> Lots => Set<Lots>();
        public DbSet<LotsPositions> LotsPositions => Set<LotsPositions>();
        public DbSet<Stocks> Stocks => Set<Stocks>();
        public DbSet<Merchandises> Merchandises => Set<Merchandises>();
        public DbSet<RecordEntrance> RecordEntrances => Set<RecordEntrance>();
        public DbSet<ReceptionEntrance> ReceptionEntrances => Set<ReceptionEntrance>();
        public DbSet<EntranceDucats> EntranceDucats => Set<EntranceDucats>();
        public DbSet<DucatRegistry> DucatRegistries => Set<DucatRegistry>();
        public DbSet<WarehouseAssignments> WarehouseAssignments => Set<WarehouseAssignments>();
        public DbSet<DucatRegistryDetails> DucatRegistryDetails => Set<DucatRegistryDetails>();
        public DbSet<UnloadingDetails> UnloadingDetails => Set<UnloadingDetails>();
        public DbSet<Discrepancies> Discrepancies => Set<Discrepancies>();
        public DbSet<ManifestCancellations> ManifestCancellations => Set<ManifestCancellations>();
        public DbSet<WarehouseReceipts> WarehouseReceipts => Set<WarehouseReceipts>();
        public DbSet<StepExecutionLogs> StepExecutionLogs => Set<StepExecutionLogs>();
        public DbSet<CustomsDeclarations> CustomsDeclarations => Set<CustomsDeclarations>();
        public DbSet<CustomsDeclarationDetails> CustomsDeclarationDetails => Set<CustomsDeclarationDetails>();
        public DbSet<UnloadingCrewAssignments> UnloadingCrewAssignments => Set<UnloadingCrewAssignments>();
        public DbSet<UnloadingMachineryAssignments> UnloadingMachineryAssignments => Set<UnloadingMachineryAssignments>();
        public DbSet<WarehouseMachinery> WarehouseMachineries => Set<WarehouseMachinery>();
        public DbSet<WarehouseStaff> WarehouseStaffs => Set<WarehouseStaff>();
        public DbSet<StockPlacements> StockPlacements => Set<StockPlacements>();
        public DbSet<StockFootprintCells> StockFootprintCells => Set<StockFootprintCells>();
        public DbSet<ReassignmentSessions> ReassignmentSessions => Set<ReassignmentSessions>();
        public DbSet<ReassignmentSessionOwnershipLog> ReassignmentSessionOwnershipLogs => Set<ReassignmentSessionOwnershipLog>();
        public DbSet<ReassignmentMemoryItems> ReassignmentMemoryItems => Set<ReassignmentMemoryItems>();
        public DbSet<StockMovementEvents> StockMovementEvents => Set<StockMovementEvents>();
        #endregion

        #region Compras
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<SupplierDetails> SupplierDetails => Set<SupplierDetails>();
        public DbSet<Quotation> Quotations => Set<Quotation>();

        public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
        public DbSet<PurchaseRequest> PurchaseRequests => Set<PurchaseRequest>();
        public DbSet<PurchaseRequestItem> PurchaseRequestItems => Set<PurchaseRequestItem>();
        public DbSet<RequisitionAccountingReview> RequisitionAccountingReviews => Set<RequisitionAccountingReview>();
        public DbSet<RequisitionManagementReview> RequisitionManagementReviews => Set<RequisitionManagementReview>();

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
            modelBuilder.HasPostgresEnum<DeductionPaymentStatus>("public","deduction_payment_status_enum");
            modelBuilder.HasPostgresEnum<PayrollPeriod>("public","payroll_period_enum");
            modelBuilder.HasPostgresEnum<OSStatus>("public","oss_status_enum");
            modelBuilder.HasPostgresEnum<RecordEntranceStatus>("public","record_entrance_status_enum");
            modelBuilder.HasPostgresEnum<WarehouseType>("public","warehouse_type_enum");
            modelBuilder.HasPostgresEnum<ConstitutionType>("public","constitution_type_enum");
            modelBuilder.HasPostgresEnum<UnitMeasureType>("public","unit_measure_type_enum");
            modelBuilder.HasPostgresEnum<ProductUsageType>("public","product_usage_type_enum");
            modelBuilder.HasPostgresEnum<DucaStatus>("public","duca_status_enum");
            modelBuilder.HasPostgresEnum<DocumentType>("public","document_type_enum");
            modelBuilder.HasPostgresEnum<MachineryType>("public","machinery_type_enum");

            modelBuilder.HasPostgresEnum<PriorityLevel>("public", "priority_level_enum"); 
            modelBuilder.HasPostgresEnum<DestinationRequest>("public", "destination_request_enum"); 

            modelBuilder.HasPostgresEnum<PurchaseRequestType>("public","purchase_request_type_enum");
            modelBuilder.HasPostgresEnum<PurchaseRequestStatus>("public","purchase_request_status_enum");
            modelBuilder.HasPostgresEnum<TimeType>("public", "time_type_enum");
            modelBuilder.HasPostgresEnum<SectionType>("public", "section_type_enum");
            modelBuilder.HasPostgresEnum<SectionStorageType>("public", "section_storage_type_enum");
            modelBuilder.HasPostgresEnum<AccountingReviewStatus>("public", "accounting_review_status_enum");
            modelBuilder.HasPostgresEnum<ManagementReviewStatus>("public", "management_review_status_enum");
            modelBuilder.HasPostgresEnum<RackUsageProfile>("public", "rack_usage_profile_enum");
            modelBuilder.HasPostgresEnum<RackStatus>("public", "rack_status_enum");
            modelBuilder.HasPostgresEnum<TransportUnit>("public", "transport_unit_enum");
            modelBuilder.HasPostgresEnum<DucaType>("public", "duca_type_enum");
            modelBuilder.HasPostgresEnum<ReassignmentSessionStatus>("public", "reassignment_session_status_enum");



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