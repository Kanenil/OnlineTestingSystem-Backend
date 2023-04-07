using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OnlineTestingSystem.Presistence
{
    public class OnlineTestingDbContextFactory :
        IDesignTimeDbContextFactory<OnlineTestingDbContext>
    {
        public OnlineTestingDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<OnlineTestingDbContext>();
            var connectionString = configuration.GetConnectionString("OnlineTestingConnectionString");

            builder.UseNpgsql(connectionString);

            return new OnlineTestingDbContext(builder.Options);
        }
    }
}
