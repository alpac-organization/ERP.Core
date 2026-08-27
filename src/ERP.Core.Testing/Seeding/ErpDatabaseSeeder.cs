using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Testing.Seeding
{
    public static class ErpDatabaseSeeder
    {
        public static async Task SeedAsync(ErpDbContext dbContext, ErpSeedData seedData)
        {
            #region Catalogos
            dbContext.Companies.AddRange(seedData.Companies);
            dbContext.Branches.AddRange(seedData.Branches);
            dbContext.WorkAreas.AddRange(seedData.WorkAreas);
            #endregion

            #region Autenticación
            dbContext.Users.AddRange(seedData.Users);
            dbContext.Profiles.AddRange(seedData.Profiles);
            dbContext.Notifications.AddRange(seedData.Notifications);
            dbContext.Devices.AddRange(seedData.Devices);
            #endregion

            await dbContext.SaveChangesAsync();
        }
    }
}