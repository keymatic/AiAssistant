using Key.AiAssistant.Domain;
using Key.AiAssistant.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Key.AiAssistant.Store
{
    public class AiAssistantDbContext : DbContext
    {
        public AiAssistantDbContext(DbContextOptions<AiAssistantDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AiAssistantDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                entry.Entity.UpdatedDate = DateTimeOffset.UtcNow;
                entry.Entity.UpdatedBy = "system";

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTimeOffset.UtcNow;
                    entry.Entity.CreatedBy = "system";
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Prompt> Prompts { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}