using Bogus;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Testing.Seeding
{
    public static class ErpSeedDataFactory
    {
        private const int Seed = 20260827;

        public const string DefaultPassword = "Admin123!";
        public static readonly Guid AlpacAreaTiId = Guid.Parse("11111111-0000-0000-0000-000000000001");
        private static readonly string DefaultPasswordHash = BCrypt.Net.BCrypt.HashPassword(DefaultPassword, workFactor: 11);

        #region RolesId
        private static readonly Guid RoleAdministratorId = Guid.Parse("aaaaaaaa-0000-0000-0000-000000000001");
        private static readonly Guid RoleOperatorId = Guid.Parse("aaaaaaaa-0000-0000-0000-000000000002");
        private static readonly Guid RoleSupervisorId = Guid.Parse("aaaaaaaa-0000-0000-0000-000000000003");
        private static readonly Guid RoleManagerId = Guid.Parse("aaaaaaaa-0000-0000-0000-000000000004");

        #endregion

        #region ProductAndCatalogIds
        public static readonly Guid CategoryGeneralId = Guid.Parse("cccccccc-0000-0000-0000-000000000001");
        public static readonly Guid UnitMeasureWeightId = Guid.Parse("dddddddd-0000-0000-0000-000000000001");
        public static readonly Guid UnitMeasureUnitId   = Guid.Parse("dddddddd-0000-0000-0000-000000000002");
        public static readonly Guid ProductOfficeId   = Guid.Parse("eeeeeeee-0000-0000-0000-000000000001");
        public static readonly Guid ProductSupplyId   = Guid.Parse("eeeeeeee-0000-0000-0000-000000000002");

        #endregion

        #region CostCenterIds
        public static readonly Guid CostCenterAlpacItId = Guid.Parse("ffffffff-0000-0000-0000-000000000001");
        public static readonly Guid CostCenterAlpacWhId = Guid.Parse("ffffffff-0000-0000-0000-000000000002");
        public static readonly Guid CostCenterAminsaId  = Guid.Parse("ffffffff-0000-0000-0000-000000000003");
        public static readonly Guid CostCenterAvasaId   = Guid.Parse("ffffffff-0000-0000-0000-000000000004");
        public static readonly Guid CostCenterVigemsaId = Guid.Parse("ffffffff-0000-0000-0000-000000000005");
        public static readonly Guid CostCenterTmnId     = Guid.Parse("ffffffff-0000-0000-0000-000000000006");

        #endregion

        public static ErpSeedData CreateScenario()
        {
            Randomizer.Seed = new Random(Seed);
            var faker = new Faker("es");
            var data = new ErpSeedData();

            SeedBaseRoles(data);

            SeedBaseModules(data);

            SeedBaseProductCatalog(data);   
            // Agregar Semillas de Companies
            SeedBaseCompanies(data, faker);

            // Agregar Semillas de WorkAreas
            SeedBaseWorkAreas(data, faker);

            // Agregar Semillas de CostCenters
            SeedBaseCostCenters(data);

            // Agregar Semillas de Branches (sucursales)
            SeedBaseBranches(data, faker);

            // Agregar Semillas de Usuarios
            SeedBaseUsers(data, faker);

            // Agregar Semillas de Perfiles por empresa
            SeedBaseProfiles(data, faker);

            SeedBaseWarehouses(data);
            SeedBaseWarehouseCapacities(data);
            SeedBaseSections(data);
            SeedBaseSectionCapacities(data);

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

        private static void SeedBaseProductCatalog(ErpSeedData data)
        {
            data.CategoryProducts.Add(new CategoryProducts
            {
                Id = CategoryGeneralId,
                Name = "Categoría general",
                Code = "CAT-GEN",
                IsActive = true
            });

            data.UnitMeasures.AddRange([

            new UnitMeasure
            {
                 Id = UnitMeasureUnitId,
                 Code = "UND",
                 Name = "Unidad",
                 Symbol = "u",
                 Type = UnitMeasureType.Unit, 
                 IsActive = true
            },

            new UnitMeasure
            {
                Id = UnitMeasureWeightId,
                Code = "KG",
                Name = "Kilogramo",
                Symbol = "kg",
                Type = UnitMeasureType.Weight,
                IsActive = true
            }

           ]);

            data.Products.AddRange([

             new Product
            {
                Id = ProductOfficeId,
                ProductName = "Producto oficina",
                Description = "Producto seed para tests",
                CategoryId = CategoryGeneralId
            },

            new Product
            {
               Id = ProductSupplyId,
               ProductName = "Insumo general",
               Description = "Producto seed alterno",
               CategoryId = CategoryGeneralId
            }
            ]);

        }
        public static void SeedBaseModules(ErpSeedData data)
        {
            List<Module> modules = [
                new Module{
                    Id = Guid.Parse("bbbbbbbb-0000-0000-0000-000000000001"),
                    Code = "COM-129U",
                    ModuleName = "Gestión de compras",
                    Description = "Módulo de compras",
                    PathRedirect = "purchasing",
                    ImageUrl = null,
                    IsActive = true 
                },
                new Module{
                    Id = Guid.Parse("bbbbbbbb-0000-0000-0000-000000000002"),
                    Code = "FIN-567W",
                    ModuleName = "Gestión de Finanzas",
                    Description = "Módulo de Finanzas",
                    PathRedirect = "finance",
                    ImageUrl = null,
                    IsActive = true 
                },
                new Module{
                    Id = Guid.Parse("bbbbbbbb-0000-0000-0000-000000000003"),
                    Code = "GRC-873Y",
                    ModuleName = "Gestión de Gerencia",
                    Description = "Módulo de Gerencia",
                    PathRedirect = "management",
                    ImageUrl = null,
                    IsActive = true 
                },
                new Module{
                    Id = Guid.Parse("bbbbbbbb-0000-0000-0000-000000000004"),
                    Code = "ALM-MAN-2KE4",
                    ModuleName = "Almacen Managua",
                    Description = "Gestion de Almacen Managua",
                    PathRedirect = "warehouse",
                    ImageUrl = null,
                    IsActive = true 
                },
            ];

            data.Modules.AddRange(modules);
        }
        public static void SeedBaseRoles(ErpSeedData data)
        {
            List<Role> roles = [
                new Role{
                    Id          = RoleAdministratorId,
                    RoleName    = "Administrator",
                    Description = "Administrator for ERP-System",
                    RoleType    = RoleType.Administrator,
                },
                new Role{

                    Id          = RoleSupervisorId,
                    RoleName    = "Supervisor",
                    Description = "Supervisor for ERP-System",
                    RoleType    = RoleType.Supervisor,
                },
                new Role{

                    Id          = RoleManagerId,
                    RoleName    = "Manager",
                    Description = "Manager for ERP-System",
                    RoleType    = RoleType.Manager,
                },
                new Role{

                    Id          = RoleOperatorId,
                    RoleName    = "Operator",
                    Description = "Operator for ERP-System",
                    RoleType    = RoleType.Operator,
                },
            ];
            data.Roles.AddRange(roles);
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

        private static void SeedBaseCostCenters(ErpSeedData data)
        {
            var costCenters = new List<CostCenter>
            {
                // ALPAC - Tecnología de la Información
                new CostCenter
                {
                    Id = CostCenterAlpacItId,
                    WorkAreaId = Guid.Parse("11111111-0000-0000-0000-000000000001"),
                    CostCenterName = "Gerencia de Informática",
                    Description = "Centro de costos de TI",
                    CostCenterCode = 1001,
                    CoilCode = 10,
                    IsActive = true
                },
                // ALPAC - Almacén y Logística
                new CostCenter
                {
                    Id = CostCenterAlpacWhId,
                    WorkAreaId = Guid.Parse("11111111-0000-0000-0000-000000000002"),
                    CostCenterName = "Almacén y Logística",
                    Description = "Centro de costos de almacén",
                    CostCenterCode = 1002,
                    CoilCode = 20,
                    IsActive = true
                },
                // AMINSA
                new CostCenter
                {
                    Id = CostCenterAminsaId,
                    WorkAreaId = Guid.Parse("22222222-0000-0000-0000-000000000001"),
                    CostCenterName = "Operaciones Marítimas",
                    Description = "Centro de costos operaciones",
                    CostCenterCode = 2001,
                    CoilCode = 10,
                    IsActive = true
                },
                // AVASA
                new CostCenter
                {
                    Id = CostCenterAvasaId,
                    WorkAreaId = Guid.Parse("33333333-0000-0000-0000-000000000001"),
                    CostCenterName = "Producción y Granja",
                    Description = "Centro de costos producción",
                    CostCenterCode = 3001,
                    CoilCode = 10,
                    IsActive = true
                },
                // VIGEMSA
                new CostCenter
                {
                    Id = CostCenterVigemsaId,
                    WorkAreaId = Guid.Parse("44444444-0000-0000-0000-000000000001"),
                    CostCenterName = "Seguridad Operativa",
                    Description = "Centro de costos seguridad",
                    CostCenterCode = 4001,
                    CoilCode = 10,
                    IsActive = true
                },
                // TMN
                new CostCenter
                {
                    Id = CostCenterTmnId,
                    WorkAreaId = Guid.Parse("55555555-0000-0000-0000-000000000001"),
                    CostCenterName = "Flotas y Transportación",
                    Description = "Centro de costos flotas",
                    CostCenterCode = 5001,
                    CoilCode = 10,
                    IsActive = true
                }
            };

            data.CostCenters.AddRange(costCenters);
        }

        private static void SeedBaseWarehouses(ErpSeedData data)
        {
            List<Warehouses> warehouses = [
                new Warehouses
                {
                    Id = Guid.Parse("66666666-b000-0000-0000-000000000001"),
                    Code = "B2F",
                    IsActive = true,
                    WarehouseType = WarehouseType.Fiscal,
                },
                new Warehouses
                {
                    Id = Guid.Parse("66666666-b000-0000-0000-000000000002"),
                    Code = "B3F",
                    IsActive = true,
                    WarehouseType = WarehouseType.Fiscal,
                },
            ];

            data.Warehouses.AddRange(warehouses);
        }

        private static void SeedBaseWarehouseCapacities(ErpSeedData data)
        {
            List<WarehouseCapacity> warehouseCapacities = [
                new WarehouseCapacity
                {
                    Id = Guid.Parse("77777777-b000-0000-0000-000000000001"),
                    WarehouseId = Guid.Parse("66666666-b000-0000-0000-000000000001"),
                    HasMargins = true,
                    MinimumHeight = 3.12m,
                    MaximumHeight = 5.12m,
                    MarginTop = 0.6m,
                    MarginBottom = 0.6m,
                    MarginLeft = 0.6m,
                    MarginRight = 0.6m,
                    Width = 12.50m,
                    Length = 18.00m,
                    UnusedAreaM2 = 18.00m,
                    AvailableAreaWithMarginM2 = 198.00m,
                    TotalAreaM2 = 225.00m,
                    UnoccupiedChargeableAreaM2 = 30.00m,
                    OccupiedChargeableAreaM2 = 45.00m,
                    PercentageAvailableAreaWithMarginM2 = 88.00m,
                    UnusedVolumenM3 = 36.00m,
                    AvailableVolumenWithMarginM3 = 540.00m,
                    TotalVolumenM3 = 585.00m,
                    UnoccupiedChargeableVolumenM3 = 65.00m,
                    OccupiedChargeableVolumenM3 = 80.00m,
                    PercentageAvailableVolumenWithMarginM3 = 92.31m,
                },
                new WarehouseCapacity
                {
                    Id = Guid.Parse("77777777-b000-0000-0000-000000000002"),
                    WarehouseId = Guid.Parse("66666666-b000-0000-0000-000000000002"),
                    HasMargins = true,
                    MinimumHeight = 2.80m,
                    MaximumHeight = 4.90m,
                    MarginTop = 0.5m,
                    MarginBottom = 0.5m,
                    MarginLeft = 0.5m,
                    MarginRight = 0.5m,
                    Width = 14.00m,
                    Length = 20.00m,
                    UnusedAreaM2 = 20.00m,
                    AvailableAreaWithMarginM2 = 252.00m,
                    TotalAreaM2 = 280.00m,
                    UnoccupiedChargeableAreaM2 = 35.00m,
                    OccupiedChargeableAreaM2 = 52.00m,
                    PercentageAvailableAreaWithMarginM2 = 90.00m,
                    UnusedVolumenM3 = 40.00m,
                    AvailableVolumenWithMarginM3 = 610.00m,
                    TotalVolumenM3 = 650.00m,
                    UnoccupiedChargeableVolumenM3 = 70.00m,
                    OccupiedChargeableVolumenM3 = 88.00m,
                    PercentageAvailableVolumenWithMarginM3 = 93.85m,
                },
            ];

            data.WarehouseCapacities.AddRange(warehouseCapacities);
        }

        private static void SeedBaseSections(ErpSeedData data)
        {
            List<Sections> sections = [
                new Sections
                {
                    Id = Guid.Parse("88888888-b000-0000-0000-000000000001"),
                    Code = "SEC-B2F-01",
                    IsActive = true,
                    SectionType = SectionType.Storage,
                    SectionStorageType = SectionStorageType.Racks,
                    WarehouseId = Guid.Parse("66666666-b000-0000-0000-000000000001"),
                    AllowsStorageAisle = false,
                    IsStorageEnabledAisle = false,
                },
                new Sections
                {
                    Id = Guid.Parse("88888888-b000-0000-0000-000000000002"),
                    Code = "SEC-B3F-01",
                    IsActive = true,
                    SectionType = SectionType.Storage,
                    SectionStorageType = SectionStorageType.Lots,
                    WarehouseId = Guid.Parse("66666666-b000-0000-0000-000000000002"),
                    AllowsStorageAisle = false,
                    IsStorageEnabledAisle = false,
                },
            ];

            data.Sections.AddRange(sections);
        }

        private static void SeedBaseSectionCapacities(ErpSeedData data)
        {
            List<SectionCapacity> sectionCapacities = [
                new SectionCapacity
                {
                    Id = Guid.Parse("99999999-b000-0000-0000-000000000001"),
                    SectionId = Guid.Parse("88888888-b000-0000-0000-000000000001"),
                    Width = 6.00m,
                    Length = 18.00m,
                    UnusedAreaM2 = 12.00m,
                    AvailableAreaWithMarginM2 = 84.00m,
                    TotalAreaM2 = 108.00m,
                    UnoccupiedChargeableAreaM2 = 15.00m,
                    OccupiedChargeableAreaM2 = 22.00m,
                    PercentageAvailableAreaWithMarginM2 = 77.78m,
                },
                new SectionCapacity
                {
                    Id = Guid.Parse("99999999-b000-0000-0000-000000000002"),
                    SectionId = Guid.Parse("88888888-b000-0000-0000-000000000002"),
                    Width = 8.00m,
                    Length = 20.00m,
                    UnusedAreaM2 = 16.00m,
                    AvailableAreaWithMarginM2 = 120.00m,
                    TotalAreaM2 = 160.00m,
                    UnoccupiedChargeableAreaM2 = 18.00m,
                    OccupiedChargeableAreaM2 = 26.00m,
                    PercentageAvailableAreaWithMarginM2 = 75.00m,
                },
            ];

            data.SectionCapacities.AddRange(sectionCapacities);
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
                    // Obtener el CostCenterId correspondiente al área
                    var costCenter = data.CostCenters.FirstOrDefault(c => c.WorkAreaId == area.Id);
                    var costCenterId = costCenter?.Id ?? Guid.Empty;

                    for (int i = 0; i < 2; i++)
                    {
                        var user = NewUser(faker, Guid.NewGuid(), domain);
                        data.Users.Add(user);
                        
                        var branch = data.Branches.First(b => b.CompanyId == companyId);
                        data.Profiles.Add(NewProfile(faker, user.Id, companyId, branch.Id, costCenterId));
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

            // Profiles are already created in SeedBaseUsers, just add cross-company profiles for ALPAC users
            var alpacUserIds = data.Profiles
                .Where(p => p.CompanyId == companyAlpac)
                .Select(p => p.UserId)
                .Distinct()
                .ToList();

            var otherCompanies = new[] { companyAminsa, companyAvasa, companyVigemsa, companyTmn };

            foreach (var userId in alpacUserIds)
            {
                foreach (var companyId in otherCompanies)
                {
                    var branch = data.Branches.First(b => b.CompanyId == companyId);
                    // Get the cost center for this company (first work area's cost center)
                    var workArea = data.WorkAreas.First(w => w.CompanyId == companyId);
                    var costCenter = data.CostCenters.FirstOrDefault(c => c.WorkAreaId == workArea.Id);
                    var costCenterId = costCenter?.Id ?? Guid.Empty;
                    
                    data.Profiles.Add(NewProfile(faker, userId, companyId, branch.Id, costCenterId));
                }
            }
        }

        #endregion

        #region Constructores

        private static User NewUser(Faker faker, Guid userId, string domain)
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
            };
        }

        private static UserProfile NewProfile(Faker faker, Guid userId, Guid companyId, Guid branchId, Guid costCenterId) => new()
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            CompanyId = companyId,
            BranchId = branchId,
            CostCenterId = costCenterId,
            IsActive = true
        };

        #endregion
    }
}