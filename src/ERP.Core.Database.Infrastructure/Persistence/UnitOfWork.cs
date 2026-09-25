using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;

namespace ERP.Core.Database.Infrastructure.Persistence
{
public class UnitOfWork(
        ErpDbContext _context,
        ICompaniesRepository companiesRepository,
        IModulesRepository modulesRepository,
        IUsersRepository usersRepository,
        IUserProfilesRepository userProfilesRepository,
        IDevicesRepository devicesRepository,
        INotificationsRepository notificationsRepository,
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
        IWarehouseLocationRepository locationRepository,
        ICategoryProductsRepository categoryProductsRepository,
        IProductsRepository productsRepository,
        IWarehousesRepository warehouseRepository,
        IWarehouseCapacityRepository warehouseCapacityRepository,
        ISectionCapacityRepository sectionCapacityRepository,
        ISectionCoordinatesRepository sectionCoordinatesRepository,
        IRackCapacityRepository rackCapacityRepository,
        ILotsCapacityRepository lotsCapacityRepository,
        IRackCoordinateRepository rackCoordinateRepository,
        ILotCoordinateRepository lotCoordinateRepository,
        IOutsourcedWarehousesRepository outsourcedWarehousesRepository,
        IDucatRegistryDetailsRepository ducatRegistryDetailsRepository,
        IDucatRegistryRepository ducatRegistryRepository,
        IReceptionEntranceRepository receptiondEntranceRepository,
        IReceptionTransportEntranceRepository receptionTransportEntranceRepository,
        IStepExecutionLogsRepository stepExecutionLogsRepository,
        ISuppliersRepository suppliersRepository,
        IQuotesRepository quotesRepository,
        IUnitsMeasurementRepository unitsMeasurementRepository,
        ISuppliersDetailsRepository suppliersDetailsRepository,
        IPurchaseRequestsRepository purchaseRequestsRepository,
        IPurchaseRequestItemsRepository purchaseRequestItemsRepository,
        IPurchaseOrdersRepository purchaseOrdersRepository,
        IMerchandisesRepository merchandisesRepository,
        ISectionsRepository sectionsRepository,
        ISectionPositionsRepository sectionPositionsRepository,
        IPurchaseRequestsReviewedAccountingRepository purchaseRequestsReviewedAccountingRepository,
        IPurchaseRequestsReviewedManagementRepository purchaseRequestsReviewedManagementRepository,
        IRacksRepository racksRepository,
        IRackPositionsRepository rackPositionsRepository,
        ILotsRepository lotsRepository,
        ILotsPositionsRepository lotsPositionsRepository,
        IWarehouseAssignmentsRepository warehouseAssignmentsRepository,
        ICrewAssignmentsRepository crewAssignmentsRepository,
        IMachineryAssignmentsRepository machineryAssignmentsRepository,
        IMachineryRepository machineryRepository,
        ICustomsBranchesRepository customsBranchesRepository,
        IShippingComapaniesRepository shippingComapaniesRepository,
        IStockPlacementsRepository stockPlacementsRepository,
        IStockFootprintCellsRepository stockFootprintCellsRepository,
        IReassignmentSessionsRepository reassignmentSessionsRepository,
        IReassignmentSessionOwnershipLogRepository reassignmentSessionOwnershipLogRepository,
        IReassignmentMemoryItemsRepository reassignmentMemoryItemsRepository,
        IStockMovementEventsRepository stockMovementEventsRepository,
        IStockRepository stockRepository,
        IUnloadingDetailsRepository unloadingDetailsRepository,
        IUnloadingPalletsRepository unloadingPalletsRepository,
        IUnloadingSuppliesRepository unloadingSuppliesRepository,
        ISuppliesRepository suppliesRepository,
        IUnloadingPositionsReservationsRepository unloadingPositionsReservationsRepository,
        IWarehouseTasksRepository warehouseTasksRepository,
        IWarehouseTaskEventsRepository warehouseTaskEventsRepository,
        IWarehouseTaskOwnershipLogsRepository warehouseTaskOwnershipLogsRepository,
        ICustomersRepository customersRepository,
        IInvoicesRepository invoicesRepository,
        IOperationalOrdersRepository operationalOrdersRepository,
        IOperationalServicesRepository operationalServicesRepository,
        IServicesOrdersRepository servicesOrdersRepository,
        ICustomerBranchesRepository customerBranchesRepository,
        ICustomerCreditInformationsRepository customerCreditInformationsRepository
    ) : IUnitOfWork
    {
        public ErpDbContext Context => _context;

        public ICompaniesRepository Companies => companiesRepository;
        public IModulesRepository Modules => modulesRepository;
        public IUsersRepository Users => usersRepository;
        public IDevicesRepository Devices => devicesRepository;
        public IUserProfilesRepository Profiles => userProfilesRepository;
        public INotificationsRepository Notifications => notificationsRepository;
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
        public IHolidaysRepository Holidays => holidaysRepository;
        public IWorkAreasRepository WorkAreas => workAreasRepository;
        public ICostCentersRepository CostCenters => costCentersRepository;
        public IJobPositionsRepository JobPositions => jobPositionsRepository;
        public ITypesAccountingPayrollRepository TypesAccountingPayroll => typesAccountingPayrollRepository;
        public IAssistanceControlRepository AssistanceControls => assistanceControlRepository;
        public IWarehouseLocationRepository Locations => locationRepository;
        public ICustomsBranchesRepository CustomsBranches => customsBranchesRepository;
        public ICategoryProductsRepository CategoryProducts => categoryProductsRepository;
        public IUnitsMeasurementRepository UnitsMeasurement => unitsMeasurementRepository;
        public IShippingComapaniesRepository ShippingComapanies => shippingComapaniesRepository;
        public ISuppliesRepository Supplies => suppliesRepository;
        #endregion

        #region Warehouse
        public IProductsRepository Products => productsRepository;
        public IWarehousesRepository Warehouses => warehouseRepository;
        public IWarehouseCapacityRepository WarehouseCapacities => warehouseCapacityRepository;
        public ISectionCapacityRepository SectionCapacities => sectionCapacityRepository;
        public ISectionCoordinatesRepository SectionCoordinates => sectionCoordinatesRepository;
        public IRackCapacityRepository RackCapacities => rackCapacityRepository;
        public ILotsCapacityRepository LotsCapacities => lotsCapacityRepository;
        public IOutsourcedWarehousesRepository OutsourcedWarehouses => outsourcedWarehousesRepository;
        public IMerchandisesRepository Merchandises => merchandisesRepository;
        public IDucatRegistryDetailsRepository DucatRegistryDetails => ducatRegistryDetailsRepository;
        public IDucatRegistryRepository DucatRegistries => ducatRegistryRepository;
        public IReceptionEntranceRepository ReceptionEntrance => receptiondEntranceRepository;
        public IReceptionTransportEntranceRepository ReceptionTransportEntrance => receptionTransportEntranceRepository;
        public IStepExecutionLogsRepository StepExecutionLogs => stepExecutionLogsRepository;
        public ISectionsRepository Sections => sectionsRepository;
        public IRacksRepository Racks => racksRepository;
        public IRackPositionsRepository RackPositions => rackPositionsRepository;
        public IRackCoordinateRepository RackCoordinates => rackCoordinateRepository;
        public ILotsRepository Lots => lotsRepository;
        public ILotsPositionsRepository LotsPositions => lotsPositionsRepository;
        public ILotCoordinateRepository LotCoordinates => lotCoordinateRepository;
        public ISectionPositionsRepository SectionPositionsRepository => sectionPositionsRepository;
        public IWarehouseAssignmentsRepository WarehouseAssignments => warehouseAssignmentsRepository;
        public ICrewAssignmentsRepository CrewAssignments => crewAssignmentsRepository;
        public IMachineryAssignmentsRepository MachineryAssignments => machineryAssignmentsRepository;
        public IMachineryRepository Machineries => machineryRepository;
        public IStockPlacementsRepository StockPlacements => stockPlacementsRepository;
        public IStockFootprintCellsRepository StockFootprintCells => stockFootprintCellsRepository;
        public IReassignmentSessionsRepository ReassignmentSessions => reassignmentSessionsRepository;
        public IReassignmentSessionOwnershipLogRepository ReassignmentSessionOwnershipLog => reassignmentSessionOwnershipLogRepository;
        public IReassignmentMemoryItemsRepository ReassignmentMemoryItems => reassignmentMemoryItemsRepository;
        public IStockMovementEventsRepository StockMovementEvents => stockMovementEventsRepository;
        public IStockRepository Stock => stockRepository;
        public IUnloadingDetailsRepository UnloadingDetails => unloadingDetailsRepository;
        public IUnloadingPalletsRepository UnloadingPallets => unloadingPalletsRepository;
        public IUnloadingSuppliesRepository UnloadingSupplies => unloadingSuppliesRepository;
        public IUnloadingPositionsReservationsRepository UnloadingPositionsReservations => unloadingPositionsReservationsRepository;
        public IWarehouseTasksRepository WarehouseTasks => warehouseTasksRepository;
        public IWarehouseTaskEventsRepository WarehouseTaskEvents => warehouseTaskEventsRepository;
        public IWarehouseTaskOwnershipLogsRepository WarehouseTaskOwnershipLogs => warehouseTaskOwnershipLogsRepository;
        #endregion

        #region Operations
        public ICustomersRepository Customers => customersRepository;
        public IInvoicesRepository Invoices => invoicesRepository;
        public IOperationalOrdersRepository OperationalOrders => operationalOrdersRepository;
        public IOperationalServicesRepository OperationalServices => operationalServicesRepository;
        public IServicesOrdersRepository ServicesOrders => servicesOrdersRepository;
        public ICustomerBranchesRepository CustomerBranches => customerBranchesRepository;
        public ICustomerCreditInformationsRepository CustomerCreditInformations => customerCreditInformationsRepository;
        #endregion

        #region Shopping
        public IQuotesRepository Quotations => quotesRepository;
        public ISuppliersRepository Suppliers => suppliersRepository;
        public ISuppliersDetailsRepository SuppliersDetails => suppliersDetailsRepository;
        public IPurchaseRequestsRepository PurchaseRequests => purchaseRequestsRepository;
        public IPurchaseRequestItemsRepository PurchaseRequestItems => purchaseRequestItemsRepository;
        public IPurchaseOrdersRepository PurchaseOrders => purchaseOrdersRepository;
        public IPurchaseRequestsReviewedAccountingRepository PurchaseRequestsReviewedAccounting => purchaseRequestsReviewedAccountingRepository;
        public IPurchaseRequestsReviewedManagementRepository PurchaseRequestsReviewedManagement => purchaseRequestsReviewedManagementRepository;
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