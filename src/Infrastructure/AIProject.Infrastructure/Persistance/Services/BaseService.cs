using Microsoft.EntityFrameworkCore;

namespace AIProject.Infrastructure.Persistance.Services
{
    public abstract class BaseService<T> where T : class
    {
        private readonly ApplicationContext _context;

        protected BaseService(ApplicationContext context)
        {
            _context = context;
        }
        protected DbSet<T> Table { get => _context.Set<T>(); }
        
    }
}
