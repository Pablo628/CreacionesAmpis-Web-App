using PrivateBlog.Persistence.Data;
using PrivateBlog.Application.Contracts.Persisntece;

namespace PrivateBlog.Persistence.UnitOfWorks
{
    public class EfCoreUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public EfCoreUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task RollbackAsync()
        {
            return Task.CompletedTask;
        }
    }
}

