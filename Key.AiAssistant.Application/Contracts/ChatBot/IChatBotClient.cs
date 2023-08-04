using Key.AiAssistant.Domain;

namespace Key.AiAssistant.Application.Contracts.ChatBot
{
    public interface IChatBotClient
    {
        Task<Conversation> OptimizeResumeAsync(string resume, string vacancy);
        Task<Conversation> SendAsync(string[] promptMessages, CancellationToken cancellationToken = default);
    }
}
