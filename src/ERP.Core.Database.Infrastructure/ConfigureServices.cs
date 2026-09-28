using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Infrastructure.Services;

using ERP.Core.Database.Infrastructure.Persistence;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Infrastructure.Services.WarehouseCapacities;
using ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll;
using ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping;
using ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Repositories.Authentication;
using ERP.Core.Database.Infrastructure.Persistence.Repositories.Operations;

using ERP.Core.Database.Application.Commons.Interfaces.Services;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;
using ERP.Core.Database.Application.Commons.Interfaces.Services.WarehouseCapacities;

namespace ERP.Core.Database.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddErpDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ErpConnectionDatabase");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("No se encontró la cadena 'ErpConnectionDatabase'.");
            }

            services.AddDbContext<ErpDbContext>(options =>
                options.ConfigureWarnings(warnings =>
                        warnings.Ignore(RelationalEventId.PendingModelChangesWarning))
                    .UseNpgsql(connectionString, npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsAssembly(typeof(ErpDbContext).Assembly.FullName);
                })
            );

            //Repositories
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IDevicesRepository, DevicesRepository>();
            services.AddScoped<IUserProfilesRepository, UserProfilesRepository>();
            services.AddScoped<ISessionsRepository, SessionsRepository>();
            services.AddScoped<INotificationsRepository, NotificationsRepository>();
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
            services.AddScoped<IWarehouseLocationRepository, WarehouseLocationRepository>();
            services.AddScoped<IAssistanceControlRepository, AssistanceControlRepository>();
            services.AddScoped<ICategoryProductsRepository, CategoryProductsRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();

            services.AddScoped<IWarehouseCapacityRepository, WarehouseCapacityRepository>();
            services.AddScoped<ISectionCapacityRepository, SectionCapacityRepository>();
            services.AddScoped<ISectionCoordinatesRepository, SectionCoordinatesRepository>();
            services.AddScoped<IRackCapacityRepository, RackCapacityRepository>();
            services.AddScoped<ILotsCapacityRepository, LotsCapacityRepository>();
            services.AddScoped<IWarehousesRepository, WarehousesRepository>();
            services.AddScoped<ILotCoordinateRepository, LotCoordinateRepository>();
            services.AddScoped<IRackCoordinateRepository, RackCoordinateRepository>();
            services.AddScoped<IUnitsMeasurementRepository, UnitsMeasurementRepository>();

            // Operations
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IInvoicesRepository, InvoicesRepository>();
            services.AddScoped<IOperationalOrdersRepository, OperationalOrdersRepository>();
            services.AddScoped<IOperationalServicesRepository, OperationalServicesRepository>();
            services.AddScoped<IServicesOrdersRepository, ServicesOrdersRepository>();
            services.AddScoped<ICustomerBranchesRepository, CustomerBranchesRepository>();
            services.AddScoped<ICustomerCreditInformationsRepository, CustomerCreditInformationsRepository>();
            services.AddScoped<ISuppliersRepository, SuppliersRepository>();
            services.AddScoped<ISuppliersDetailsRepository, SuppliersDetailsRepository>();
            services.AddScoped<IPurchaseOrdersRepository, PurchaseOrdersRepository>();
            services.AddScoped<IPurchaseRequestsRepository, PurchaseRequestsRepository>();
            services.AddScoped<IPurchaseRequestItemsRepository, PurchaseRequestItemsRepository>();
            services.AddScoped<IQuotesRepository, QuotesRepository>();
            services.AddScoped<ISupplierPaymentMethodRepository, SupplierPaymentMethodRepository>();
            services.AddScoped<ILotsRepository, LotsRepository>();
            services.AddScoped<ILotsPositionsRepository, LotsPositionsRepository>();
            services.AddScoped<ICustomsBranchesRepository, CustomsBranchesRepository>();
            services.AddScoped<IShippingComapaniesRepository, ShippingComapaniesRepository>();

            #region 
            services.AddScoped<IReceptionEntranceRepository, ReceptionEntranceReporitory>();
            services.AddScoped<IReceptionTransportEntranceRepository, ReceptionTransportEntranceRepository>();
            services.AddScoped<IDucatRegistryDetailsRepository, DucatRegistryDetailsRepository>();
            services.AddScoped<IDucatRegistryRepository, DucatRegistryRepository>();
            services.AddScoped<IStepExecutionLogsRepository, StepExecutionLogsRepository>();
            services.AddScoped<IOutsourcedWarehousesRepository, OutsourcedWarehousesRepository>();
            services.AddScoped<IMerchandisesRepository, MerchandisesRepository>();
            services.AddScoped<ISectionsRepository, SectionsRepository>();
            services.AddScoped<IRacksRepository, RacksRepository>();
            services.AddScoped<IRackPositionsRepository, RackPositionsRepository>();
            services.AddScoped<ISectionPositionsRepository, SectionPositionRepository>();
            services.AddScoped<IWarehouseAssignmentsRepository, WarehouseAssignmentsRepository>();
            services.AddScoped<ICrewAssignmentsRepository, CrewAssignmentsRepository>();
            services.AddScoped<IMachineryRepository, MachineryRepository>();
            services.AddScoped<IPurchaseRequestsReviewedAccountingRepository, PurchaseRequestsReviewedAccountingRepository>();
            services.AddScoped<IPurchaseRequestsReviewedManagementRepository, PurchaseRequestsReviewedManagementRepository>();
            services.AddScoped<IStockPlacementsRepository, StockPlacementsRepository>();
            services.AddScoped<IStockFootprintCellsRepository, StockFootprintCellsRepository>();
            services.AddScoped<IReassignmentSessionsRepository, ReassignmentSessionsRepository>();
            services.AddScoped<IReassignmentSessionOwnershipLogRepository, ReassignmentSessionOwnershipLogRepository>();
            services.AddScoped<IWarehouseTasksRepository, WarehouseTasksRepository>();
            services.AddScoped<IWarehouseTaskEventsRepository, WarehouseTaskEventsRepository>();
            services.AddScoped<IWarehouseTaskOwnershipLogsRepository, WarehouseTaskOwnershipLogsRepository>();
            services.AddScoped<IReassignmentMemoryItemsRepository, ReassignmentMemoryItemsRepository>();
            services.AddScoped<IStockMovementEventsRepository, StockMovementEventsRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IUnloadingDetailsRepository, UnloadingDetailsRepository>();
            services.AddScoped<IUnloadingPalletsRepository, UnloadingPalletsRepository>();
            services.AddScoped<IUnloadingSuppliesRepository, UnloadingSuppliesRepository>();
            services.AddScoped<ISuppliesRepository, SuppliesRepository>();
            services.AddScoped<IUnloadingPositionsReservationsRepository, UnloadingPositionReservationsRepository>();
            services.AddScoped<IAssignmentsMachineryRepository, AssignmentMachineryRepository>();
            services.AddScoped<IAssignmentCollaboratorsRepository, AssignmentCollaboratorRepository>();
            services.AddScoped<IServicesOrdersRequisitionsRepository, ServicesOrdersRequisitionsRepository>();
            #endregion

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Servicios 
            services.AddScoped<ICodeGenerator, CodeGenerator>();
            services.AddScoped<ICalculatorCapacities, CalculatorCapacities>();
            services.AddScoped<IRackCapacityCalculator, RackCapacityCalculator>();
            services.AddScoped<ILotCapacityCalculator, LotCapacityCalculator>();
            services.AddScoped<ISectionCapacityCalculator, SectionCapacityCalculator>();
            services.AddScoped<IWarehouseCapacityCalculator, WarehouseCapacityCalculator>();

            return services;
        }
    }
}