using Bogus;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Testing.Seeding
{
    public static class ErpSeedDataFactory
    {
        private const int Seed = 20260827;

        public const string DefaultPassword = "Admin123!";
        public static readonly Guid AlpacAreaTiId = Guid.Parse("11111111-0000-0000-0000-000000000001");
        private static readonly string DefaultPasswordHash = BCrypt.Net.BCrypt.HashPassword(DefaultPassword, workFactor: 11);

        public static ErpSeedData CreateScenario()
        {
            Randomizer.Seed = new Random(Seed);
            var faker = new Faker("es");
            var data = new ErpSeedData();

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
                    BranchCode = "ALPAC-01",
                    BranchName = "ALPAC - Sucursal Central",
                    CompanyAlias = "ALPAC",
                    IsActive = true
                },
                new Branch
                {
                    Id = Guid.Parse("22222222-b000-0000-0000-000000000001"),
                    CompanyId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    BranchCode = "AMINSA-01",
                    BranchName = "AMINSA - Sucursal Central",
                    CompanyAlias = "AMINSA",
                    IsActive = true
                },
                new Branch
                {
                    Id = Guid.Parse("33333333-b000-0000-0000-000000000001"),
                    CompanyId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    BranchCode = "AVASA-01",
                    BranchName = "AVASA - Sucursal Central",
                    CompanyAlias = "AVASA",
                    IsActive = true
                },
                new Branch
                {
                    Id = Guid.Parse("44444444-b000-0000-0000-000000000001"),
                    CompanyId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    BranchCode = "VIGEMSA-01",
                    BranchName = "VIGEMSA - Sucursal Central",
                    CompanyAlias = "VIGEMSA",
                    IsActive = true
                },
                new Branch
                {
                    Id = Guid.Parse("55555555-b000-0000-0000-000000000001"),
                    CompanyId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    BranchCode = "TMN-01",
                    BranchName = "TMN - Sucursal Central",
                    CompanyAlias = "TMN",
                    IsActive = true
                }
            ];

            data.Branches.AddRange(branches);
        }

        private static readonly Dictionary<string, string> CompanyDomains = new()
        {
            ["ALPAC"] = "alpac.com",
            ["AMINSA"] = "aminsa.com",
            ["AVASA"] = "avasa.com",
            ["VIGEMSA"] = "vigemsa.com",
            ["TMN"] = "tmn.com"
        };

        private static void SeedBaseUsers(ErpSeedData data, Faker faker)
        {
            // company alias -> (companyId)
            var companyContext = new (string Alias, Guid CompanyId)[]
            {
                ("ALPAC",   Guid.Parse("11111111-1111-1111-1111-111111111111")),
                ("AMINSA",  Guid.Parse("22222222-2222-2222-2222-222222222222")),
                ("AVASA",   Guid.Parse("33333333-3333-3333-3333-333333333333")),
                ("VIGEMSA", Guid.Parse("44444444-4444-4444-4444-444444444444")),
                ("TMN",     Guid.Parse("55555555-5555-5555-5555-555555555555")),
            };

            foreach (var (alias, companyId) in companyContext)
            {
                var domain = CompanyDomains[alias];

                var areas = data.WorkAreas.Where(w => w.CompanyId == companyId).ToList();

                foreach (var area in areas)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        var user = NewUser(faker, Guid.NewGuid(), area.Id, domain);
                        data.Users.Add(user);
                    }
                }
            }
        }

        private static void SeedBaseProfiles(ErpSeedData data, Faker faker)
        {
            var companyAlpac = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var companyAminsa = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var companyAvasa = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var companyVigemsa = Guid.Parse("44444444-4444-4444-4444-444444444444");
            var companyTmn = Guid.Parse("55555555-5555-5555-5555-555555555555");

            var areaTiAlpac = Guid.Parse("11111111-0000-0000-0000-000000000001");



            foreach (var user in data.Users)
            {
                var area = data.WorkAreas.First(w => w.Id == user.AreaId);
                var branch = data.Branches.First(b => b.CompanyId == area.CompanyId);
                data.Profiles.Add(NewProfile(faker, user.Id, area.CompanyId, branch.Id));
            }

            var tiUsers = data.Users.Where(u => u.AreaId == areaTiAlpac).ToList();
            var otherCompanies = new[] { companyAminsa, companyAvasa, companyVigemsa, companyTmn };

            foreach (var user in tiUsers)
            {
                foreach (var companyId in otherCompanies)
                {
                    var branch = data.Branches.First(b => b.CompanyId == companyId);
                    data.Profiles.Add(NewProfile(faker, user.Id, companyId, branch.Id));
                }
            }
        }

        #endregion

        #region Constructores

        private static User NewUser(Faker faker, Guid userId, Guid areaId, string domain)
        {
            var firstName = faker.Name.FirstName();
            var lastName = faker.Name.LastName();
            var userName = faker.Internet.UserName(firstName, lastName).ToLower();

            return new User
            {
                Id = userId,
                UserName = userName,
                Email = $"{userName}@{domain}",
                Fullname = $"{firstName} {lastName}",
                PasswordHash = DefaultPasswordHash,
                IdentificationNumber = faker.Random.ReplaceNumbers("001-######-000#") + faker.Random.String2(1, "ABCDEFGHIJKLMNOPQRSTUVWXYZ"),
                UserType = UserType.StandardUser,
                UserStatus = UserStatus.Active,
                AreaId = areaId,
            };
        }

        private static UserProfile NewProfile(Faker faker, Guid userId, Guid companyId, Guid branchId) => new()
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            CompanyId = companyId,
            BranchId = branchId,
            IsActive = true
        };

        #endregion
    }
}