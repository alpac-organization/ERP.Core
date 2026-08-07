using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;

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
        IWarehouseDetailsRepository warehouseDetailsRepository,
        IWarehouseCapacityRepository warehouseCapacityRepository,
        IOutsourcedWarehousesRepository outsourcedWarehousesRepository,
        IServiceOrdersRepository serviceOrdersRepository,
        IEntranceDucatsRepository entranceDucatsRepository,
        IDucatRegistryDetailsRepository ducatRegistryDetailsRepository,
        IDucatRegistryRepository ducatRegistryRepository,
        IReceptionEntranceRepository receptiondEntranceRepository,
        IRecordEntranceRepository recordEntranceRepository,
        IStepExecutionLogsRepository stepExecutionLogsRepository,
        ISuppliersRepository suppliersRepository,
        IWorkflowStepDefinitionsRepository workflowStepDefinitionsRepository,
        IQuotesRepository quotesRepository,
        IUnitsMeasurementRepository unitsMeasurementRepository,
        ISuppliersDetailsRepository suppliersDetailsRepository,

        IPurchaseRequestsRepository purchaseRequestsRepository,
        IPurchaseRequestItemsRepository purchaseRequestItemsRepository,
        IPurchaseOrdersRepository purchaseOrdersRepository,
        ICustomsDeclarationsRepository customsDeclarationsRepository,
        ICustomsDeclarationDetailsRepository customsDeclarationDetailsRepository,
        ITransportUnitRepository transportUnitRepository,

        IMerchandisesRepository merchandisesRepository
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
        public IHolidaysRepository Holidays  => holidaysRepository;
        public IWorkAreasRepository WorkAreas => workAreasRepository;
        public ICostCentersRepository CostCenters => costCentersRepository;
        public IJobPositionsRepository JobPositions => jobPositionsRepository;
        public ITypesAccountingPayrollRepository TypesAccountingPayroll => typesAccountingPayrollRepository;
        public IAssistanceControlRepository AssistanceControls => assistanceControlRepository;
        public ILocationsRepository Locations => locationRepository;
        public ICategoryProductsRepository CategoryProducts => categoryProductsRepository;
        public ICustomerTypeRepository CustomerType => customerTypeRepository;
        public IUnitsMeasurementRepository UnitsMeasurement => unitsMeasurementRepository;
        public ITransportUnitRepository TransportUnit => transportUnitRepository;
        #endregion

        #region Warehouse
        public ICustomerRepository Customers => customerRepository;
        public IProductsRepository Products => productsRepository;
        public IWarehousesRepository Warehouses => warehouseRepository;
        public IWarehouseDetailsRepository WarehouseDetails => warehouseDetailsRepository;
        public IWarehouseCapacityRepository WarehouseCapacities => warehouseCapacityRepository;
        public IOutsourcedWarehousesRepository OutsourcedWarehouses => outsourcedWarehousesRepository;
        public IServiceOrdersRepository ServiceOrders => serviceOrdersRepository;
        public IEntranceDucatsRepository EntranceDucats => entranceDucatsRepository;
        public IMerchandisesRepository Merchandises => merchandisesRepository;
        public IDucatRegistryDetailsRepository DucatRegistryDetails => ducatRegistryDetailsRepository;
        public IDucatRegistryRepository DucatRegistries => ducatRegistryRepository;
        public IReceptionEntranceRepository ReceptionEntrance => receptiondEntranceRepository;
        public IRecordEntranceRepository RecordEntrance => recordEntranceRepository;
        public IStepExecutionLogsRepository StepExecutionLogs => stepExecutionLogsRepository;
        public IWorkflowStepDefinitionsRepository WorkflowStepDefinitions => workflowStepDefinitionsRepository;
        public ICustomsDeclarationsRepository CustomsDeclarations => customsDeclarationsRepository;
        public ICustomsDeclarationDetailsRepository CustomsDeclarationDetails => customsDeclarationDetailsRepository;
        #endregion

        #region Shopping
        public IQuotesRepository Quotations => quotesRepository;
        public ISuppliersRepository Suppliers => suppliersRepository;
        public ISuppliersDetailsRepository SuppliersDetails => suppliersDetailsRepository;
        public IPurchaseRequestsRepository PurchaseRequests => purchaseRequestsRepository;
        public IPurchaseRequestItemsRepository PurchaseRequestItems => purchaseRequestItemsRepository;
        public IPurchaseOrdersRepository PurchaseOrders => purchaseOrdersRepository;
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