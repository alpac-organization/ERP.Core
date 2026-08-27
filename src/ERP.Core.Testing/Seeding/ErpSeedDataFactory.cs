using Bogus;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Testing.Seeding
{
    public static class ErpSeedDataFactory
    {
        private const int Seed = 20260827;

        public static ErpSeedData CreateScenario()
        {
            Randomizer.Seed = new Random(Seed);
            var faker       = new Faker("es");
            var data        = new ErpSeedData();

            // Agregar Semillas de Companies
            SeedBaseCompanies(data, faker);

            // Agregar Semillas de WorkAreas
            SeedBaseWorkAreas(data, faker);

            // Agregar Semillas de Branches (sucursales)
            SeedBaseBranches(data, faker);

            // Agregar Semillas de Usuarios
            SeedBaseUsers(data, faker);

            // Agregar Semillas de Perfiles por empresa
            SeedBaseProfiles(data, faker);

            return data;
        }

        #region Seeds
        private static void SeedBaseCompanies(ErpSeedData data, Faker faker)
        {
            List<Company> companies = [
                new Company
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Code = "ALPAC",
                    Alias = "ALPAC",
                    CompanieName = "Almacenadora del Pacífico S.A.",
                    Ruc = faker.Random.ReplaceNumbers("J031#########"),
                    IsActive = true
                },
                new Company
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Code = "AMINSA",
                    Alias = "AMINSA",
                    CompanieName = "Agencia Maritima Internacional S.A.",
                    Ruc = faker.Random.ReplaceNumbers("J031#########"),
                    IsActive = true
                },
                new Company
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Code = "AVASA",
                    Alias = "AVASA",
                    CompanieName = "Avícola Agropecuaria S.A.",
                    Ruc = faker.Random.ReplaceNumbers("J031#########"),
                    IsActive = true
                },
                new Company
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    Code = "VIGEMSA",
                    Alias = "VIGEMSA",
                    CompanieName = "Vigilancia Empresarial S.A.",
                    Ruc = faker.Random.ReplaceNumbers("J031#########"),
                    IsActive = true
                },
                new Company
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    Code = "TMN",
                    Alias = "TMN",
                    CompanieName = "Transportes Multimodales S.A.",
                    Ruc = faker.Random.ReplaceNumbers("J031#########"),
                    IsActive = true
                }
            ];

            data.Companies.AddRange(companies);
        }

        private static void SeedBaseWorkAreas(ErpSeedData data, Faker faker)
        {
            List<WorkArea> workAreas = [
                // ALPAC Areas
                new WorkArea
                {
                    Id = Guid.Parse("11111111-0000-0000-0000-000000000001"),
                    CompanyId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    WorkAreaCode = 10,
                    WorkAreaName = "Tecnología de la Información",
                    Description = "Soporte, desarrollo e infraestructura tecnológica",
                    IsActive = true
                },
                new WorkArea
                {
                    Id = Guid.Parse("11111111-0000-0000-0000-000000000002"),
                    CompanyId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    WorkAreaCode = 20,
                    WorkAreaName = "Almacén y Logística",
                    Description = "Gestión de bodegas e inventario",
                    IsActive = true
                },

                // AMINSA Areas
                new WorkArea
                {
                    Id = Guid.Parse("22222222-0000-0000-0000-000000000001"),
                    CompanyId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    WorkAreaCode = 10,
                    WorkAreaName = "Operaciones Marítimas",
                    Description = "Coordinación de embarques y logística naviera",
                    IsActive = true
                },

                // AVASA Areas
                new WorkArea
                {
                    Id = Guid.Parse("33333333-0000-0000-0000-000000000001"),
                    CompanyId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    WorkAreaCode = 10,
                    WorkAreaName = "Producción y Granja",
                    Description = "Control de procesos productivos agropecuarios",
                    IsActive = true
                },

                // VIGEMSA Areas
                new WorkArea
                {
                    Id = Guid.Parse("44444444-0000-0000-0000-000000000001"),
                    CompanyId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    WorkAreaCode = 10,
                    WorkAreaName = "Seguridad Operativa",
                    Description = "Supervisión de personal de campo y guardias",
                    IsActive = true
                },

                // TMN Areas
                new WorkArea
                {
                    Id = Guid.Parse("55555555-0000-0000-0000-000000000001"),
                    CompanyId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    WorkAreaCode = 10,
                    WorkAreaName = "Flotas y Transportación",
                    Description = "Mantenimiento de unidades y rutas de transporte",
                    IsActive = true
                }
            ];

            data.WorkAreas.AddRange(workAreas);
        }

        private static void SeedBaseBranches(ErpSeedData data, Faker faker)
        {
            List<Branch> branches = [
                new Branch
                {
                    Id = Guid.Parse("11111111-b000-0000-0000-000000000001"),
                    CompanyId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    BranchName = "ALPAC - Sucursal Central",
                    IsActive = true
                },
                new Branch
                {
                    Id = Guid.Parse("22222222-b000-0000-0000-000000000001"),
                    CompanyId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    BranchName = "AMINSA - Sucursal Central",
                    IsActive = true
                },
                new Branch
                {
                    Id = Guid.Parse("33333333-b000-0000-0000-000000000001"),
                    CompanyId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    BranchName = "AVASA - Sucursal Central",
                    IsActive = true
                },
                new Branch
                {
                    Id = Guid.Parse("44444444-b000-0000-0000-000000000001"),
                    CompanyId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    BranchName = "VIGEMSA - Sucursal Central",
                    IsActive = true
                },
                new Branch
                {
                    Id = Guid.Parse("55555555-b000-0000-0000-000000000001"),
                    CompanyId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    BranchName = "TMN - Sucursal Central",
                    IsActive = true
                }
            ];

            data.Branches.AddRange(branches);
        }

        private static readonly Dictionary<string, string> CompanyDomains = new()
        {
            ["ALPAC"]   = "alpac.com",
            ["AMINSA"]  = "aminsa.com",
            ["AVASA"]   = "avasa.com",
            ["VIGEMSA"] = "vigemsa.com",
            ["TMN"]     = "tmn.com"
        };

        private static void SeedBaseUsers(ErpSeedData data, Faker faker)
        {
            // company alias -> (companyId, branchId)
            var companyContext = new (string Alias, Guid CompanyId, Guid BranchId)[]
            {
                ("ALPAC",   Guid.Parse("11111111-1111-1111-1111-111111111111"), Guid.Parse("11111111-b000-0000-0000-000000000001")),
                ("AMINSA",  Guid.Parse("22222222-2222-2222-2222-222222222222"), Guid.Parse("22222222-b000-0000-0000-000000000001")),
                ("AVASA",   Guid.Parse("33333333-3333-3333-3333-333333333333"), Guid.Parse("33333333-b000-0000-0000-000000000001")),
                ("VIGEMSA", Guid.Parse("44444444-4444-4444-4444-444444444444"), Guid.Parse("44444444-b000-0000-0000-000000000001")),
                ("TMN",     Guid.Parse("55555555-5555-5555-5555-555555555555"), Guid.Parse("55555555-b000-0000-0000-000000000001")),
            };

            foreach (var (alias, companyId, branchId) in companyContext)
            {
                var domain = CompanyDomains[alias];

                var areas = data.WorkAreas.Where(w => w.CompanyId == companyId).ToList();

                foreach (var area in areas)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        var user = NewUser(faker, Guid.NewGuid(), branchId, area.Id, domain);
                        data.Users.Add(user);
                    }
                }
            }
        }

        private static void SeedBaseProfiles(ErpSeedData data, Faker faker)
        {
            var companyAlpac   = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var companyAminsa  = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var companyAvasa   = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var companyVigemsa = Guid.Parse("44444444-4444-4444-4444-444444444444");
            var companyTmn     = Guid.Parse("55555555-5555-5555-5555-555555555555");

            var areaTiAlpac = Guid.Parse("11111111-0000-0000-0000-000000000001");

            foreach (var user in data.Users)
            {
                var area = data.WorkAreas.First(w => w.Id == user.AreaId);
                data.Profiles.Add(NewProfile(faker, user.Id, area.CompanyId));
            }

            var tiUsers = data.Users.Where(u => u.AreaId == areaTiAlpac).ToList();
            var otherCompanies = new[] { companyAminsa, companyAvasa, companyVigemsa, companyTmn };

            foreach (var user in tiUsers)
            {
                foreach (var companyId in otherCompanies)
                {
                    data.Profiles.Add(NewProfile(faker, user.Id, companyId));
                }
            }
        }

        #endregion

        #region Constructores

        private static User NewUser(Faker faker, Guid userId, Guid branchId, Guid areaId, string domain)
        {
            var firstName = faker.Name.FirstName();
            var lastName  = faker.Name.LastName();
            var userName  = faker.Internet.UserName(firstName, lastName).ToLower();

            return new User
            {
                Id                   = userId,
                UserName             = userName,
                Email                = $"{userName}@{domain}",
                Fullname             = $"{firstName} {lastName}",
                PasswordHash         = "$2a$11$e8Z9U7f0X9aK1YmZ9u2kEO8R01zVpW8fH.eYwzU2kEO8R01zVpW8f",
                IdentificationNumber = faker.Random.ReplaceNumbers("001-######-000#") + faker.Random.String2(1, "ABCDEFGHIJKLMNOPQRSTUVWXYZ"),
                UserType             = UserType.StandardUser,
                UserStatus           = UserStatus.Active,
                AreaId               = areaId,
                BranchId             = branchId
            };
        }

        private static UserProfile NewProfile(Faker faker, Guid userId, Guid companyId) => new()
        {
            Id        = Guid.NewGuid(),
            UserId    = userId,
            CompanyId = companyId,
            IsActive  = true
        };

        #endregion
    }
}