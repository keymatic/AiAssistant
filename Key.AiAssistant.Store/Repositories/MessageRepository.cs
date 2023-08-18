using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Domain;
using Microsoft.EntityFrameworkCore;

namespace Key.AiAssistant.Store.Repositories
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(AiAssistantDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Message?> GetWithDetail(int conversationId, int id)
        {
            return await DbContext.Messages
                .Include(t => t.Conversation)
                .FirstOrDefaultAsync(t => t.Id == id && t.ConversationId == conversationId);
        }

        public async Task<List<Message>> GetAll(int conversationId)
        {
            return await DbContext.Messages
                .Where(t => t.ConversationId == conversationId)
                .OrderByDescending(t => t.CreatedDate)
                .ToListAsync();
        }
    }
}
