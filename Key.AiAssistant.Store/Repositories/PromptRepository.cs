using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Domain;

namespace Key.AiAssistant.Store.Repositories
{
    public class PromptRepository : RepositoryBase<Prompt>, IPromptRepository
    {
        public PromptRepository(AiAssistantDbContext dbContext) : base(dbContext)
        {
        }
    }
}
