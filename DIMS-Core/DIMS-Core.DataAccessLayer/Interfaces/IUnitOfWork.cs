using System.Threading.Tasks;

namespace DIMS_Core.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        ISampleRepository SampleRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
        IDirectionRepository DirectionRepository { get; }
        ITaskRepository TaskRepository { get; }
        IVTaskRepository VTaskRepository { get; }
        IVUserTrackRepository VUserTrackRepository { get; }
        IVUserProfileRepository VUserProfileRepository { get; }

        Task SaveChanges();
    }
}