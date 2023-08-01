using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Key.AiAssistant.Store.Configuration
{
    public class DbContextDesignFactory : IDesignTimeDbContextFactory<AiAssistantDbContext>
    {
        public AiAssistantDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<AiAssistantDbContext>()
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<AiAssistantDbContext>();
            var connectionString = configuration.GetConnectionString("AiAssistantConnectionString");

            builder.UseNpgsql(connectionString);

            return new AiAssistantDbContext(builder.Options);
        }
    }
}
