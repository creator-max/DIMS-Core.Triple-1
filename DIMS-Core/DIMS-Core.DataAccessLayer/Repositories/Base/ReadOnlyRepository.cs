using DIMS_Core.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS_Core.DataAccessLayer.Repositories.Base
{
    public abstract class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbSet<TEntity> CurrentSet;
        private readonly DbContext _context;

        protected ReadOnlyRepository(DbContext context)
        {
            _context = context;
        }

        public void Dispose() => _context?.Dispose();

        public IQueryable<TEntity> GetAll() => _context.Set<TEntity>().AsNoTracking();

        public Task<TEntity> GetById(int id)
        {
            return CurrentSet.FindAsync(id)
                             .AsTask();
        }
    }
}
