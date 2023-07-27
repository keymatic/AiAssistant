using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Store.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Key.AiAssistant.Store.Configuration
{
    public static class StoreServicesRegistration
    {
        public static IServiceCollection ConfigureStoreServices(this IServiceCollection services, string aiAssistantConnectionString)
        {
            services.AddDbContext<AiAssistantDbContext>(options =>
                options.UseNpgsql(aiAssistantConnectionString,
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
