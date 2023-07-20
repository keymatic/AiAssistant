using Key.AiAssistant.Domain;

namespace Key.AiAssistant.Application.Contracts.Persistence
{
    public interface IMessageRepository : IRepositoryBase<Message>
    {
        Task<Message> GetWithDetail(int id);
    }
}
