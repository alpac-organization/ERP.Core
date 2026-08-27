using Bogus;

using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Testing.Seeding;

/// <summary>
/// Genera el "script" de data inicial ficticia (empresas, sucursales, áreas, usuarios,
/// perfiles y notificaciones) usando Bogus con una semilla determinista.
/// Incluye siempre un escenario "ancla" (empresa + usuario) que es el que usan los tokens JWT
/// para autenticar las peticiones de prueba.
/// </summary>
public static class ErpSeedDataFactory
{
    public static readonly Guid DefaultCompanyId = Guid.Parse("22222222-2222-2222-2222-222222222222");
    public static readonly Guid DefaultBranchId = Guid.Parse("33333333-3333-3333-3333-333333333333");
    public static readonly Guid DefaultWorkAreaId = Guid.Parse("44444444-4444-4444-4444-444444444444");
    public static readonly Guid DefaultUserId = Guid.Parse("11111111-1111-1111-1111-111111111111");

    private const int Seed = 20260827;

    /// <summary>
    /// Construye el script completo. El escenario ancla siempre está presente; los parámetros
    /// permiten añadir más empresas/usuarios/notificaciones ficticios.
    /// </summary>
    public static ErpSeedData CreateScenario(int extraCompanies = 0, int usersPerCompany = 3, int notificationsPerUser = 0)
    {
        Randomizer.Seed = new Random(Seed);
        var faker = new Faker("es");
        var data = new ErpSeedData();

        AddCompanyWithAreaAndBranch(
            data,
            faker,
            companyId: DefaultCompanyId,
            branchId: DefaultBranchId,
            areaId: DefaultWorkAreaId,
            companyCode: "C-001",
            branchCode: "B-001");

        var anchorUser = NewUser(faker, DefaultUserId, DefaultBranchId, DefaultWorkAreaId);
        data.Users.Add(anchorUser);
        data.Profiles.Add(NewProfile(faker, DefaultUserId, DefaultCompanyId));

        if (notificationsPerUser > 0)
        {
            data.Notifications.AddRange(GenerateNotifications(notificationsPerUser, DefaultUserId));
        }

        for (var i = 0; i < extraCompanies; i++)
        {
            var companyId = Guid.NewGuid();
            var branchId = Guid.NewGuid();
            var areaId = Guid.NewGuid();

            AddCompanyWithAreaAndBranch(data, faker, companyId, branchId, areaId, $"C-{i + 2:000}", $"B-{i + 2:000}");

            for (var u = 0; u < usersPerCompany; u++)
            {
                var userId = Guid.NewGuid();
                data.Users.Add(NewUser(faker, userId, branchId, areaId));
                data.Profiles.Add(NewProfile(faker, userId, companyId));
            }
        }

        return data;
    }

    public static List<Notification> GenerateNotifications(int count, Guid userId)
    {
        Randomizer.Seed = new Random(Seed);
        var faker = new Faker("es");

        return faker.Make(count, () => new Notification
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Title = faker.Hacker.Phrase(),
            Description = faker.Lorem.Sentence(),
            WasRead = faker.Random.Bool(),
            PathRedirect = $"/notifications/{faker.Random.Guid()}"
        }).ToList();
    }

    private static void AddCompanyWithAreaAndBranch(
        ErpSeedData data,
        Faker faker,
        Guid companyId,
        Guid branchId,
        Guid areaId,
        string companyCode,
        string branchCode)
    {
        var company = new Company
        {
            Id = companyId,
            Code = companyCode,
            Alias = faker.Company.CompanyName(),
            CompanieName = faker.Company.CompanyName(),
            Ruc = faker.Random.ReplaceNumbers("###########"),
            IsActive = true
        };

        var branch = new Branch
        {
            Id = branchId,
            CompanyId = companyId,
            BranchCode = branchCode,
            BranchName = faker.Company.CatchPhrase(),
            CompanyAlias = company.Alias,
            IsActive = true,
            HasWarehouse = faker.Random.Bool()
        };

        var area = new WorkArea
        {
            Id = areaId,
            CompanyId = companyId,
            WorkAreaCode = faker.Random.Int(1, 99),
            WorkAreaName = faker.Name.JobArea(),
            Description = faker.Lorem.Sentence(),
            IsActive = true
        };

        data.Companies.Add(company);
        data.Branches.Add(branch);
        data.WorkAreas.Add(area);
    }

    private static User NewUser(Faker faker, Guid userId, Guid branchId, Guid areaId) => new()
    {
        Id = userId,
        UserName = faker.Internet.UserName(),
        Email = faker.Internet.Email(),
        Fullname = faker.Name.FullName(),
        PasswordHash = "x",
        IdentificationNumber = faker.Random.ReplaceNumbers("##############"),
        UserType = UserType.StandardUser,
        UserStatus = UserStatus.Active,
        AreaId = areaId,
        BranchId = branchId
    };

    private static UserProfile NewProfile(Faker faker, Guid userId, Guid companyId) => new()
    {
        Id = Guid.NewGuid(),
        UserId = userId,
        CompanyId = companyId,
        IsActive = true
    };
}
