using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Key.AiAssistant.Store.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly AiAssistantDbContext DbContext;

        public RepositoryBase(AiAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await DbContext.AddAsync(entity);
            return entity;
        }

        public async Task Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public async Task<bool> Exists(int id)
        {
            return await DbContext.Set<T>().AnyAsync(t => t.Id == id);
        }

        public async Task<T?> Get(int id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        
    }
}
