using Key.AiAssistant.Domain;

namespace Key.AiAssistant.Application.Contracts.Persistence
{
    public interface IMessageRepository : IRepositoryBase<Message>
    {
        Task<Message?> GetWithDetail(int conversationId, int id);
        Task<List<Message>> GetAll(int requestConversationId);
    }
}
