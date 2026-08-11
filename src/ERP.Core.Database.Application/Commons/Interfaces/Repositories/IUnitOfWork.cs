
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository Users { get; }
        IModulesRepository Modules { get; }
        ICompaniesRepository Companies { get; }
        IUserProfilesRepository Profiles { get; }
        ISessionsRepository Sessions { get; }
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
        ILocationsRepository Locations { get; }
        ICategoryProductsRepository CategoryProducts { get; }
        ICustomerTypeRepository CustomerType { get; }
        ITransportUnitRepository TransportUnit { get; }
        IUnitsMeasurementRepository UnitsMeasurement { get; }
        #endregion

        #region Warehouse
        ICustomerRepository Customers { get; }
        IProductsRepository Products { get; }
        IWarehousesRepository Warehouses { get; }
        IMerchandisesRepository Merchandises { get; }
        IWarehouseDetailsRepository WarehouseDetails { get; }
        IWarehouseCapacityRepository WarehouseCapacities { get; }
        IOutsourcedWarehousesRepository OutsourcedWarehouses { get; }
        IServiceOrdersRepository ServiceOrders { get; }
        IEntranceDucatsRepository EntranceDucats { get; }
        IDucatRegistryRepository DucatRegistries { get; }
        IDucatRegistryDetailsRepository DucatRegistryDetails { get; }
        IReceptionEntranceRepository ReceptionEntrance { get; }
        IRecordEntranceRepository RecordEntrance { get; }
        IStepExecutionLogsRepository StepExecutionLogs { get; }
        IWorkflowStepDefinitionsRepository WorkflowStepDefinitions { get; }
        ICustomsDeclarationsRepository CustomsDeclarations { get; }
        ICustomsDeclarationDetailsRepository CustomsDeclarationDetails { get; }
        ISectionsRepository Sections { get; }
        ISectionOverflowCapacityRepository SectionOverflowCapacity { get; }
        #endregion

        #region ✅ Shopping
        IQuotesRepository Quotations { get; }
        ISuppliersRepository Suppliers { get; }
        ISuppliersDetailsRepository SuppliersDetails { get; }
        IPurchaseOrdersRepository PurchaseOrders { get; }
        IPurchaseRequestsRepository PurchaseRequests { get; }
        IPurchaseRequestItemsRepository PurchaseRequestItems { get; }
        IRequisitionAccountingReviewRepository RequisitionAccountingReviews { get; }
        #endregion


        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}