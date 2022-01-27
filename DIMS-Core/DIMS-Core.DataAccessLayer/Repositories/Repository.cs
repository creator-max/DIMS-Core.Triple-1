using System;
using System.Linq;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    /// <summary>
    ///     Generic Repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class Repository<TEntity> : IDisposable, IRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbSet<TEntity> CurrentSet;
        private readonly DbContext _context;

        protected Repository(DbContext context)
        {
            _context = context;
            CurrentSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return CurrentSet.AsNoTracking();
        }

        public Task<TEntity> GetById(int id)
        {
            return CurrentSet.FindAsync(id)
                             .AsTask();
        }

        public Task Create(TEntity entity)
        {
            return CurrentSet.AddAsync(entity)
                             .AsTask();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity)
                    .State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            CurrentSet.Remove(entity);
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        #region Disposable

        public void Dispose()
        {
            _context.Dispose();
        }

        #endregion Disposable
    }
}