using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication;

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
        IAssignedTravelExpensesHistoryRepository assignedTravelExpensesHistoryRepository,
        IAssignedTravelExpensesRepository assignedTravelExpensesRepository,
        ISubsidyRepository subsidyRepository
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
        public IAssignedTravelExpensesHistoryRepository AssignedTravelExpensesHistories => assignedTravelExpensesHistoryRepository;
        public IAssignedTravelExpensesRepository AssignedTravelExpenses => assignedTravelExpensesRepository;
        public ISubsidyRepository Subsidies => subsidyRepository;

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