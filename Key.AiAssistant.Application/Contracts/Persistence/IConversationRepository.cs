using Key.AiAssistant.Domain;

namespace Key.AiAssistant.Application.Contracts.Persistence
{
    public interface IConversationRepository : IRepositoryBase<Conversation>
    {
        Task<Conversation?> GetWithDetail(int id);
        Task<IReadOnlyList<Conversation>> GetAllWithDetail();
    }
}
