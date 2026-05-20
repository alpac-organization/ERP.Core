
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication;

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
        ITypesIncomeRepository TypesIncome { get; }
        IIncomeTaxAccrualRepository IncomeTaxAccrual { get;}
        IAssignedTravelExpensesRepository AssignedTravelExpenses  { get; }
        IProfessionalServicesPayrollsRepository ProfessionalServicesPayrolls { get; }
        IDeductionPaymentHistoryRepository DeductionPaymentHistories { get; }
        ISubsidyRepository Subsidies { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}