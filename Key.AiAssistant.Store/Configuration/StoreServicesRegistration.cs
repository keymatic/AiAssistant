using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Store.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Key.AiAssistant.Store.Configuration
{
    public static class StoreServicesRegistration
    {
        public static IServiceCollection ConfigureStoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AiAssistantDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("AiAssistantConnectionString"),
                    builder => builder.MigrationsAssembly(Assembly.GetAssembly(typeof(AiAssistantDbContext))?.GetName()
                        .Name)));


            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddScoped<IPromptRepository, PromptRepository>();
            services.AddScoped<IConversationRepository, ConversationRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            return services;
        }
    }
}
