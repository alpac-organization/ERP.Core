
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository Users { get; }
        IModulesRepository Modules { get; }
        ICompaniesRepository Companies { get; }
        IUserProfilesRepository Profiles { get; }
        ISessionsRepository Sessions { get; }
        INotificationsRepository Notifications { get; }
        IDevicesRepository Devices { get; }
        IRolesRepository Roles { get; }
        IUserModulesRoleRepository UserModules { get; }
        ICatalogsRepository CatalogsRepository { get; }
        ISubCatalogsRepository SubCatalogs { get; }
        ICollaboratorsRepository Collaborators { get; }
        IWorkingInformationRepository WorkingInformations { get; }
        IPersonalInformationRepository PersonalInformations { get; }
        ISalariesRepository Salaries { get; }
        IVacationsRepository Vacations { get; }
        IPermitApplicationsRepository PermitApplications { get; }
        IDeductionsRepository Deductions { get; }
        IPayrollsRepository Payrolls { get; }
        IOrdinaryPayrollsRepository OrdinaryPayrolls { get; }
        IWorkPositionsHistoryRepository WorkPositionHistories { get; }
        IValidityDeductionsRepository ValidityDeductions { get; }
        IIncomesRepository Incomes { get; }
        IBranchesRepository Branches { get; }
        ICustomsBranchesRepository CustomsBranches { get; }
        IIncomeTaxAccrualRepository IncomeTaxAccrual { get; }
        IAssignedTravelExpensesRepository AssignedTravelExpenses { get; }
        IProfessionalServicesPayrollsRepository ProfessionalServicesPayrolls { get; }
        IDeductionPaymentHistoryRepository DeductionPaymentHistories { get; }
        ISubsidyRepository Subsidies { get; }
        IRecordsTravelExpensePaymentsRepository RecordsTravelExpensePayments { get; }
        IPermitApplicationsPendingRepository PermitApplicationsPending { get; }
        IInssAccountingInformationRepository InssAccountingInformation { get; }
        IVacationAccrualRepository VacationAccruals { get; }

        #region Catalogos
        IHolidaysRepository Holidays { get; }
        IWorkAreasRepository WorkAreas { get; }
        ICostCentersRepository CostCenters { get; }
        ITypesIncomeRepository TypesIncome { get; }
        IJobPositionsRepository JobPositions { get; }
        ITypesSubsidyRepository TypesSubsidies { get; }
        ITypesAccountingPayrollRepository TypesAccountingPayroll { get; }
        IAssistanceControlRepository AssistanceControls { get; }
        IWarehouseLocationRepository Locations { get; }
        ICategoryProductsRepository CategoryProducts { get; }
        IUnitsMeasurementRepository UnitsMeasurement { get; }
        IShippingComapaniesRepository ShippingComapanies { get; }
        ISuppliesRepository Supplies { get; }
        #endregion

        #region Warehouse
        IProductsRepository Products { get; }
        IMerchandisesRepository Merchandises { get; }

        ILotsRepository Lots { get; }
        IRacksRepository Racks { get; }
        ISectionsRepository Sections { get; }
        IWarehouseCapacityRepository WarehouseCapacities { get; }
        ISectionCapacityRepository SectionCapacities { get; }
        ISectionCoordinatesRepository SectionCoordinates { get; }
        IRackCapacityRepository RackCapacities { get; }
        ILotsCapacityRepository LotsCapacities { get; }
        IWarehousesRepository Warehouses { get; }

        IRackPositionsRepository RackPositions { get; }
        ILotsPositionsRepository LotsPositions { get; }
        IRackCoordinateRepository RackCoordinates { get; }
        ILotCoordinateRepository LotCoordinates { get; }

        IOutsourcedWarehousesRepository OutsourcedWarehouses { get; }
        IDucatRegistryRepository DucatRegistries { get; }
        IDucatRegistryDetailsRepository DucatRegistryDetails { get; }
        IReceptionEntranceRepository ReceptionEntrance { get; }
        IReceptionTransportEntranceRepository ReceptionTransportEntrance { get; }
        IStepExecutionLogsRepository StepExecutionLogs { get; }

        ISectionPositionsRepository SectionPositionsRepository { get; }
        IWarehouseAssignmentsRepository WarehouseAssignments { get; }
        ICrewAssignmentsRepository CrewAssignments { get; }
        IMachineryAssignmentsRepository MachineryAssignments { get; }
        IMachineryRepository Machineries { get; }
        IStockPlacementsRepository StockPlacements { get; }
        IStockFootprintCellsRepository StockFootprintCells { get; }
        IReassignmentSessionsRepository ReassignmentSessions { get; }
        IReassignmentSessionOwnershipLogRepository ReassignmentSessionOwnershipLog { get; }
        IReassignmentMemoryItemsRepository ReassignmentMemoryItems { get; }
        IStockMovementEventsRepository StockMovementEvents { get; }
        IStockRepository Stock { get; }
        IUnloadingDetailsRepository UnloadingDetails { get; }
        IUnloadingPalletsRepository UnloadingPallets { get; }
        IUnloadingSuppliesRepository UnloadingSupplies { get; }
        IUnloadingPositionsReservationsRepository UnloadingPositionsReservations { get; }
        IWarehouseTasksRepository WarehouseTasks { get; }
        IWarehouseTaskEventsRepository WarehouseTaskEvents { get; }
        IWarehouseTaskOwnershipLogsRepository WarehouseTaskOwnershipLogs { get; }
        #endregion

        #region Operations
        ICustomersRepository Customers { get; }
        IInvoicesRepository Invoices { get; }
        IOperationalOrdersRepository OperationalOrders { get; }
        IOperationalServicesRepository OperationalServices { get; }
        IServicesOrdersRepository ServicesOrders { get; }
        ICustomerBranchesRepository CustomerBranches { get; }
        ICustomerCreditInformationsRepository CustomerCreditInformations { get; }
        #endregion

        #region ✅ Shopping
        IQuotesRepository Quotations { get; }
        ISuppliersRepository Suppliers { get; }
        ISuppliersDetailsRepository SuppliersDetails { get; }
        IPurchaseOrdersRepository PurchaseOrders { get; }
        IPurchaseRequestsRepository PurchaseRequests { get; }
        IPurchaseRequestItemsRepository PurchaseRequestItems { get; }
        IPurchaseRequestsReviewedAccountingRepository PurchaseRequestsReviewedAccounting { get; }
        IPurchaseRequestsReviewedManagementRepository PurchaseRequestsReviewedManagement { get; }
        #endregion


        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}