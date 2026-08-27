using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Testing.Seeding;

/// <summary>
/// Aplica un <see cref="ErpSeedData"/> (script de data ficticia) a la base de datos de test.
/// </summary>
public static class ErpDatabaseSeeder
{
    public static async Task SeedAsync(ErpDbContext dbContext, ErpSeedData seedData)
    {
        dbContext.Companies.AddRange(seedData.Companies);
        dbContext.Branches.AddRange(seedData.Branches);
        dbContext.WorkAreas.AddRange(seedData.WorkAreas);
        dbContext.Users.AddRange(seedData.Users);
        dbContext.Profiles.AddRange(seedData.Profiles);
        dbContext.Notifications.AddRange(seedData.Notifications);
        dbContext.Devices.AddRange(seedData.Devices);

        await dbContext.SaveChangesAsync();
    }
}
