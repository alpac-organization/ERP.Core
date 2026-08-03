using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Infrastructure.Services;

using ERP.Core.Database.Infrastructure.Persistence;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll;
using ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping;
using ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Repositories.Authentication;

using ERP.Core.Database.Application.Commons.Interfaces.Repositories;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication;
using ERP.Core.Database.Application.Commons.Interfaces.Services;
using ERP.Core.Manager.Api.Domain.Enums;

namespace ERP.Core.Database.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddErpDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ErpConnectionDatabase");

            if(string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("No se encontró la cadena 'ErpConnectionDatabase'.");
            }

            services.AddDbContext<ErpDbContext>(options => 
                options.UseNpgsql(connectionString, npgsqlOptions =>
                {

                    npgsqlOptions.MigrationsAssembly(typeof(ErpDbContext).Assembly.FullName);
                    
                    npgsqlOptions.MapEnum<CatalogType>("catalog_type_enum");
                    npgsqlOptions.MapEnum<RoleType>("role_type_enum");
                    npgsqlOptions.MapEnum<PermissionType>("permission_type_enum");
                    npgsqlOptions.MapEnum<UserType>("user_type_enum");
                    npgsqlOptions.MapEnum<UserStatus>("user_status_enum");
                    npgsqlOptions.MapEnum<GenderType>("gender_type_enum");
                    npgsqlOptions.MapEnum<IdentificationType>("identification_type_enum");
                    npgsqlOptions.MapEnum<CollaboratorStatus>("collaborator_status_enum");
                    npgsqlOptions.MapEnum<SalaryType>("salary_type_enum");
                    npgsqlOptions.MapEnum<Currency>("currency_enum");
                    npgsqlOptions.MapEnum<PermitApplicationStatus>("permit_application_status_enum");
                    npgsqlOptions.MapEnum<PermitApplicationType>("permit_application_type_enum");
                    npgsqlOptions.MapEnum<MaritalStatus>("marital_status_enum");
                    npgsqlOptions.MapEnum<DeductionType>("deduction_type_enum");
                    npgsqlOptions.MapEnum<PayrollStatus>("payroll_status_enum");
                    npgsqlOptions.MapEnum<PayrollType>("payroll_type_enum");
                    npgsqlOptions.MapEnum<TaxType>("tax_type_enum");
                    npgsqlOptions.MapEnum<SourceDeductionPayment>("source_deduction_payment_enum");
                    npgsqlOptions.MapEnum<DeductionStatus>("deduction_status_enum");
                    npgsqlOptions.MapEnum<DeductionPaymentStatus>("deduction_payment_status_enum");
                    npgsqlOptions.MapEnum<PayrollPeriod>("payroll_period_enum");
                    npgsqlOptions.MapEnum<OSStatus>("oss_status_enum");
                    npgsqlOptions.MapEnum<RecordEntranceStatus>("record_entrance_status_enum");
                    npgsqlOptions.MapEnum<WarehouseType>("warehouse_type_enum", "public");
                    npgsqlOptions.MapEnum<ConstitutionType>("constitution_type_enum", "public");
                    npgsqlOptions.MapEnum<UnitMeasureType>("unit_measure_type_enum", "public");
                    npgsqlOptions.MapEnum<ProductUsageType>("product_usage_type_enum", "public");
                    npgsqlOptions.MapEnum<QuotationStatus>("quotation_status_enum", "public");
                    npgsqlOptions.MapEnum<DucaStatus>("duca_status_enum", "public");
                    
                    npgsqlOptions.MapEnum<PurchaseRequestType>("purchase_request_type_enum", "public");
                    npgsqlOptions.MapEnum<PurchaseRequestStatus>("purchase_request_status_enum", "public");
                    npgsqlOptions.MapEnum<DocumentType>("document_type_enum", "public");
                })
            );

            //Repositories
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUserProfilesRepository, UserProfilesRepository>();
            services.AddScoped<ISessionsRepository, SessionsRepository>();
            services.AddScoped<ICompaniesRepository, CompaniesRepository>();
            services.AddScoped<IModulesRepository, ModulesRepository>();
            services.AddScoped<IUserModulesRoleRepository, UserModulesRoleRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<ICollaboratorsRepository, CollaboratorsRepository>();
            services.AddScoped<ICatalogsRepository, CatalogsRepository>();
            services.AddScoped<ISubCatalogsRepository, SubCatalogsRepository>();
            services.AddScoped<IPersonalInformationRepository, PersonalInformationRepository>();
            services.AddScoped<IWorkingInformationRepository, WorkingInformationRepository>();
            services.AddScoped<ISalariesRepository, SalariesRepository>();
            services.AddScoped<IVacationsRepository, VacationsRepository>();
            services.AddScoped<IPermitApplicationsRepository, PermitApplicationsRepository>();
            services.AddScoped<IDeductionsRepository, DeductionsRepository>();
            services.AddScoped<IPayrollsRepository, PayrollsRepository>();
            services.AddScoped<IOrdinaryPayrollsRepository, OrdinaryPayrollsRepository>();
            services.AddScoped<IWorkPositionsHistoryRepository, WorkPositionsHistoryRepository>();
            services.AddScoped<IValidityDeductionsRepository, ValidityDeductionsRepository>();
            services.AddScoped<IBranchesRepository, BranchesRepository>();
            services.AddScoped<IIncomesRepository, IncomesRepository>();
            services.AddScoped<ITypesIncomeRepository, TypesIncomeRepository>();
            services.AddScoped<IIncomeTaxAccrualRepository, IncomeTaxAccrualRepository>();
            services.AddScoped<IAssignedTravelExpensesRepository, AssignedTravelExpensesRepository>();
            services.AddScoped<IProfessionalServicesPayrollsRepository, ProfessionalServicesPayrollsRepository>();
            services.AddScoped<IDeductionPaymentHistoryRepository, DeductionPaymentHistoryRepository>();
            services.AddScoped<IVacationAccrualRepository, VacationAccrualRepository>();
            services.AddScoped<IChristmasBonusAccrualRepository, ChristmasBonusAccrualRepository>();
            services.AddScoped<IRecordsTravelExpensePaymentsRepository, RecordsTravelExpensePaymentsRepository>();
            services.AddScoped<ISubsidyRepository, SubsidyRepository>();
            services.AddScoped<ITypesSubsidyRepository, TypeSubsidyRepository>();
            services.AddScoped<IPermitApplicationsPendingRepository, PermitApplicationsPendingRepository>();
            services.AddScoped<IWorkAreasRepository, WorkAreasRepository>();
            services.AddScoped<IJobPositionsRepository, JobPositionsRepository>();
            services.AddScoped<ICostCentersRepository, CostCentersRepository>();
            services.AddScoped<IHolidaysRepository, HolidaysRepository>();
            services.AddScoped<IInssAccountingInformationRepository, InssAccountingInformationRepository>();
            services.AddScoped<ITypesAccountingPayrollRepository, TypesAccountingPayrollRepository>();
            services.AddScoped<ILocationsRepository, LocationsRepository>();
            services.AddScoped<IAssistanceControlRepository, AssistanceControlRepository>();
            services.AddScoped<ICategoryProductsRepository, CategoryProductsRepository>();
            services.AddScoped<ICustomerTypeRepository, CustomerTyperpository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IWarehousesRepository, WarehousesRepository>();
            services.AddScoped<IServiceOrdersRepository, ServiceOrdersRepository>();
            services.AddScoped<ISuppliersRepository, SuppliersRepository>();        
            services.AddScoped<ISuppliersDetailsRepository, SuppliersDetailsRepository>();        
            services.AddScoped<IUnitsMeasurementRepository, UnitsMeasurementRepository>();
            services.AddScoped<IQuotesRepository, QuotesRepository>();
            services.AddScoped<IQuotesDetailsRepository, QuotesDetailsRepository>();
            services.AddScoped<IQuotedProductsRepository, QuotedProductsRepository>();
            services.AddScoped<IPurchaseOrdersRepository, PurchaseOrdersRepository>();
            services.AddScoped<IPurchaseRequestsRepository, PurchaseRequestsRepository>();
            services.AddScoped<IRequestedProductsRepository, RequestedProductsRepository>();
            services.AddScoped<RequestQuotedPurchasesRepository, RequestQuotedPurchasesRepository>();

            #region 
            services.AddScoped<IRecordEntranceRepository, RecordEntranceRepository>();
            services.AddScoped<IReceptionEntranceRepository, ReceptionEntranceReporitory>();
            services.AddScoped<IEntranceDucatsRepository, EntranceDucatsRepository>();
            services.AddScoped<IDucatRegistryDetailsRepository, DucatRegistryDetailsRepository>();
            services.AddScoped<IDucatRegistryRepository, DucatRegistryRepository>();
            services.AddScoped<IStepExecutionLogsRepository, StepExecutionLogsRepository>();
            services.AddScoped<IOutsourcedWarehousesRepository, OutsourcedWarehousesRepository>();
            services.AddScoped<IWorkflowStepDefinitionsRepository, WorkflowStepDefinitionsRepository>();
            services.AddScoped<ICustomsDeclarationsRepository, CustomsDeclarationsRepository>();
            services.AddScoped<ICustomsDeclarationDetailsRepository, CustomsDeclarationDetailsRepository>();
            services.AddScoped<ITransportUnitRepository, TransportUnitRepository>();
            services.AddScoped<IRequestQuotedPurchasesRepository, RequestQuotedPurchasesRepository>();
            #endregion


            services.AddScoped<IUnitOfWork, UnitOfWork>();           

            //Servicios 
            services.AddScoped<ICodeGenerator, CodeGenerator>();

            return services;
        }
    }
}