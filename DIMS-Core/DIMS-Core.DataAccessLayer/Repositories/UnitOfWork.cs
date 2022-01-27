using System;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Context;
using DIMS_Core.DataAccessLayer.Interfaces;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DimsContext _context;
        private ISampleRepository _sampleRepository;

        public UnitOfWork(DimsContext context)
        {
            _context = context;
        }

        public ISampleRepository SampleRepository => _sampleRepository ??= new SampleRepository(_context);

        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}