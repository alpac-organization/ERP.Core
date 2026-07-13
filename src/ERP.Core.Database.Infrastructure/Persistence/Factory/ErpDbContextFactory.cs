using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ERP.Core.Database.Infrastructure.Persistence.Factory
{
    public class ErpDbContextFactory : IDesignTimeDbContextFactory<ErpDbContext>
    {
        public ErpDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connection = configuration.GetConnectionString("ErpConnectionDatabase");

            var optionsBuilder = new DbContextOptionsBuilder<ErpDbContext>()
                .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));

            optionsBuilder.UseNpgsql(connection);

            return new ErpDbContext(optionsBuilder.Options);
        }
    }
}