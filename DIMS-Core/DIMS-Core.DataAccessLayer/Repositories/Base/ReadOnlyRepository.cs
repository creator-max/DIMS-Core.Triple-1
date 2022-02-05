using DIMS_Core.DataAccessLayer.Context;
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
        private readonly DimsContext _context;

        protected ReadOnlyRepository(DimsContext context)
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
