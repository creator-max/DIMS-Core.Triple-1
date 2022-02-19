using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Context;
using DIMS_Core.DataAccessLayer.Interfaces;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DimsContext _context;
        private ISampleRepository _sampleRepository;
        private IUserProfileRepository _userProfileRepository;
        private IDirectionRepository _directionRepository;
        private IVUserProfileRepository _vUserProfileRepository;
        private ITaskRepository _taskRepository;
        private IVUserTrackRepository _vUserTrackRepository;
        private IVTaskRepository _vTaskRepository;

        public UnitOfWork(DimsContext context)
        {
            _context = context;
        }

        public ISampleRepository SampleRepository => _sampleRepository ??= new SampleRepository(_context);
        public IUserProfileRepository UserProfileRepository => _userProfileRepository ??= new UserProfileRepository(_context);
        public IDirectionRepository DirectionRepository => _directionRepository ??= new DirectionRepository(_context);
        public IVUserProfileRepository VUserProfileRepository => _vUserProfileRepository ??= new VUserProfileRepository(_context);
        public ITaskRepository TaskRepository => _taskRepository ??= new TaskRepository(_context);
        public IVTaskRepository VTaskRepository => _vTaskRepository ??= new VTaskRepository(_context);
        public IVUserTrackRepository VUserTrackRepository => _vUserTrackRepository ??= new VUserTrackRepository(_context);

        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}