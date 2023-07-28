using Key.AiAssistant.Application.Contracts.ChatBot;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Key.AiAssistant.ChatGPT
{
    public static class ChatGptServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ChatGptSettings>(configuration.GetSection("ChatGptSettings"));
            services.AddTransient<IChatBotClient, ChatGptClient>();

            return services;
        }
    }
}
