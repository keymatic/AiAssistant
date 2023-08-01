using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Key.AiAssistant.Store.Configuration
{
    public static class DatabaseInitializer
    {
        public static void InitializeDatabase(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetRequiredService<AiAssistantDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
