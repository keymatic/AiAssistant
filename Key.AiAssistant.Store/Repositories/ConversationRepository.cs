using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Domain;
using Microsoft.EntityFrameworkCore;

namespace Key.AiAssistant.Store.Repositories
{
    public class ConversationRepository : RepositoryBase<Conversation>, IConversationRepository
    {
        public ConversationRepository(AiAssistantDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Conversation?> GetWithDetail(int id)
        {
            return await DbContext.Conversations
                .Include(t => t.Prompt)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IReadOnlyList<Conversation>> GetAllWithDetail()
        {
            return await DbContext.Conversations
                .Include(t => t.Prompt)
                .OrderByDescending(t => t.UpdatedDate)
                .ToListAsync();
        }
    }
}
