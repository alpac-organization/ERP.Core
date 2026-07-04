using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse.Managua;

namespace ERP.Core.Database.Infrastructure.Persistence
{
    public class UnitOfWork(
        ErpDbContext _context,
        ICompaniesRepository companiesRepository,
        IModulesRepository modulesRepository,
        IUsersRepository usersRepository,
        IUserProfilesRepository userProfilesRepository,
        ISessionsRepository sessionsRepository,
        IRolesRepository rolesRepository,
        IUserModulesRoleRepository userModulesRoleRepository,
        ICollaboratorsRepository collaboratorsRepository,
        ICatalogsRepository catalogsRepository,
        ISubCatalogsRepository subCatalogsRepository,
        IWorkingInformationRepository workingInformationRepository,
        IPersonalInformationRepository personalInformationRepository,
        ISalariesRepository salariesRepository,
        IVacationsRepository vacationsRepository,
        IPermitApplicationsRepository permitApplicationsRepository,
        IDeductionsRepository deductionsRepository,
        IPendingDeductionBalancesRepository pendingDeductionBalancesRepository,
        IPayrollsRepository payrollsRepository,
        IOrdinaryPayrollsRepository ordinaryPayrollsRepository,
        IWorkPositionsHistoryRepository workPositionsHistoryRepository,
        IValidityDeductionsRepository validityDeductionsRepository,
        IBranchesRepository branchesRepository,
        IIncomesRepository incomesRepository,
        ITypesIncomeRepository typesIncomeRepository,
        IIncomeTaxAccrualRepository incomeTaxAccrualRepository,
        IAssignedTravelExpensesRepository assignedTravelExpensesRepository,
        ISubsidyRepository subsidyRepository,
        IProfessionalServicesPayrollsRepository professionalServicesPayrollsRepository,
        IDeductionPaymentHistoryRepository deductionPaymentHistoryRepository,
        IChristmasBonusAccrualRepository christmasBonusAccrualRepository,
        IRecordsTravelExpensePaymentsRepository recordsTravelExpensePaymentsRepository,
        IVacationAccrualRepository vacationAccrualRepository,
        ITypesSubsidyRepository typesSubsidyRepository,
        IPermitApplicationsPendingRepository permitApplicationsPendingRepository,
        IHolidaysRepository holidaysRepository,
        IWorkAreasRepository workAreasRepository,
        ICostCentersRepository costCentersRepository,
        IJobPositionsRepository jobPositionsRepository,
        IInssAccountingInformationRepository inssAccountingInformationRepository,
        ITypesAccountingPayrollRepository typesAccountingPayrollRepository,
        IAssistanceControlRepository assistanceControlRepository,
        ILocationsRepository locationRepository,
        ICategoryProductsRepository categoryProductsRepository,
        ICustomerTypeRepository customerTypeRepository,
        ICustomerRepository customerRepository,
        IProductsRepository productsRepository,
        IWarehousesRepository warehouseRepository,
        IServiceOrdersRepository serviceOrdersRepository,
    #region bodegas Managua
        IDiscrepanciesManaguaRepository discrepanciesManaguaRepository,
        IDucatRegistryDetailsManaguaRepository ducatRegistryDetailsManaguaRepository,
        IDucatRegistryManaguaRepository ducatRegistryManaguaRepository,
        IEntranceDucatsManaguaRepository entranceDucatsManaguaRepository,
        IManifestCancellationsManaguaRepository manifestCancellationsManaguaRepository,
        IReceptionDetailsManaguaRepository receptiondDetailsManaguaRepository,
        IRecordEntranceManaguaRepository recordEntranceManaguaRepository,
        IStepExecutionLogsManaguaRepository stepExecutionLogsManaguaRepository,
        IStockManaguaRepository stockManaguaRepository,
        IUnloadingCrewAssignmentsManaguaRepository unloadingCrewAssignmentsManaguaRepository,
        IUnloadingDetailsManaguaRepository unloadingDetailsManaguaRepository,
        IUnloadingMachineryAssignmentsManaguaRepository unloadingMachineryAssignmentsManaguaRepository,
        IWarehouseAssignmentsManaguaRepository warehouseAssignmentsManaguaRepository,
        IWarehouseReceiptsManaguaRepository warehouseReceiptsManaguaRepository
    #endregion
   
    ) : IUnitOfWork
    {
        public ErpDbContext Context => _context;

        public ICompaniesRepository Companies => companiesRepository;
        public IModulesRepository Modules => modulesRepository;
        public IUsersRepository Users => usersRepository;
        public IUserProfilesRepository Profiles => userProfilesRepository;
        public ISessionsRepository Sessions => sessionsRepository;
        public IRolesRepository Roles => rolesRepository;
        public IUserModulesRoleRepository UserModules => userModulesRoleRepository;
        public ICollaboratorsRepository Collaborators => collaboratorsRepository;
        public ICatalogsRepository CatalogsRepository => catalogsRepository;
        public ISubCatalogsRepository SubCatalogs => subCatalogsRepository;
        public IPersonalInformationRepository PersonalInformations => personalInformationRepository;
        public IWorkingInformationRepository WorkingInformations => workingInformationRepository;
        public ISalariesRepository Salaries => salariesRepository;
        public IVacationsRepository Vacations => vacationsRepository;
        public IPermitApplicationsRepository PermitApplications => permitApplicationsRepository;
        public IDeductionsRepository Deductions => deductionsRepository;
        public IPendingDeductionBalancesRepository PendingDeductionBalances => pendingDeductionBalancesRepository;
        public IPayrollsRepository Payrolls => payrollsRepository;
        public IOrdinaryPayrollsRepository OrdinaryPayrolls => ordinaryPayrollsRepository;
        public IWorkPositionsHistoryRepository WorkPositionHistories => workPositionsHistoryRepository;
        public IValidityDeductionsRepository ValidityDeductions => validityDeductionsRepository;
        public IBranchesRepository Branches => branchesRepository;
        public IIncomesRepository Incomes => incomesRepository;
        public ITypesIncomeRepository TypesIncome => typesIncomeRepository;
        public IIncomeTaxAccrualRepository IncomeTaxAccrual => incomeTaxAccrualRepository;
        public IAssignedTravelExpensesRepository AssignedTravelExpenses => assignedTravelExpensesRepository;
        public IProfessionalServicesPayrollsRepository ProfessionalServicesPayrolls => professionalServicesPayrollsRepository;
        public IDeductionPaymentHistoryRepository DeductionPaymentHistories => deductionPaymentHistoryRepository;
        public IVacationAccrualRepository VacationAccruals => vacationAccrualRepository;
        public IRecordsTravelExpensePaymentsRepository RecordsTravelExpensePayments => recordsTravelExpensePaymentsRepository;
        public IChristmasBonusAccrualRepository ChristmasBonusAccruals => christmasBonusAccrualRepository;
        public ISubsidyRepository Subsidies => subsidyRepository;
        public ITypesSubsidyRepository TypesSubsidies => typesSubsidyRepository;
        public IPermitApplicationsPendingRepository PermitApplicationsPending => permitApplicationsPendingRepository;
        public IInssAccountingInformationRepository InssAccountingInformation => inssAccountingInformationRepository;

        #region Catalogos
        public IHolidaysRepository Holidays => holidaysRepository;
        public IWorkAreasRepository WorkAreas => workAreasRepository;
        public ICostCentersRepository CostCenters => costCentersRepository;
        public IJobPositionsRepository JobPositions => jobPositionsRepository;
        public ITypesAccountingPayrollRepository TypesAccountingPayroll => typesAccountingPayrollRepository;
        public IAssistanceControlRepository AssistanceControls => assistanceControlRepository;
        public ILocationsRepository Locations => locationRepository;

        public ICategoryProductsRepository CategoryProducts => categoryProductsRepository;
        public ICustomerTypeRepository CustomerType => customerTypeRepository;
        #endregion

        #region warehouse
        public ICustomerRepository Customers => customerRepository;
        public IProductsRepository Products => productsRepository;
        public IWarehousesRepository Warehouses => warehouseRepository;
        public IServiceOrdersRepository ServiceOrders => serviceOrdersRepository;
        #endregion
        #region Bodegas Managua
        public IDiscrepanciesManaguaRepository DiscrepanciesManagua => discrepanciesManaguaRepository;
        public IDucatRegistryDetailsManaguaRepository DucatRegistryDetailsManagua => ducatRegistryDetailsManaguaRepository;
        public IDucatRegistryManaguaRepository DucatRegistryManagua => ducatRegistryManaguaRepository;
        public IEntranceDucatsManaguaRepository EntranceDucatsManagua => entranceDucatsManaguaRepository;
        public IManifestCancellationsManaguaRepository ManifestCancellationsManagua => manifestCancellationsManaguaRepository;
        public IReceptionDetailsManaguaRepository ReceptionDetailsManagua => receptiondDetailsManaguaRepository;
        public IRecordEntranceManaguaRepository RecordEntranceManagua => recordEntranceManaguaRepository;
        public IStepExecutionLogsManaguaRepository StepExecutionLogsManagua => stepExecutionLogsManaguaRepository;
        public IStockManaguaRepository StockManaguaRepository => stockManaguaRepository;
        public IUnloadingCrewAssignmentsManaguaRepository UnloadingCrewAssignmentsManagua => unloadingCrewAssignmentsManaguaRepository;
        public IUnloadingDetailsManaguaRepository UnloadingDetailsManagua => unloadingDetailsManaguaRepository;
        public IUnloadingMachineryAssignmentsManaguaRepository UnloadingMachineryAssignmentsManagua => unloadingMachineryAssignmentsManaguaRepository;
        public IWarehouseAssignmentsManaguaRepository WarehouseAssignmentsManagua => warehouseAssignmentsManaguaRepository;
        public IWarehouseReceiptsManaguaRepository WarehouseReceiptsManagua => warehouseReceiptsManaguaRepository;
        #endregion



        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}