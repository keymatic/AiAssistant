using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Key.AiAssistant.Store.Configuration
{
    public class DbContextDesignFactory : IDesignTimeDbContextFactory<AiAssistantDbContext>
    {
        public AiAssistantDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AiAssistantDbContext>();
            builder.UseNpgsql("User ID=postgres;Password=mysuperpassword;Host=localhost;Port=5432;Database=keyAiAssistant;Pooling=true;",
                options => options.MigrationsAssembly(
                    Assembly.GetAssembly(typeof(AiAssistantDbContext))?.GetName().Name));

            return new AiAssistantDbContext(builder.Options);
        }
    }
}
