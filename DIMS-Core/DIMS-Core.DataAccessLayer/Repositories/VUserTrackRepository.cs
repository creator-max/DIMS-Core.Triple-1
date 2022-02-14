using DIMS_Core.DataAccessLayer.Context;
using DIMS_Core.DataAccessLayer.Repositories.Base;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    internal class VUserTrackRepository : Repository<VUserTrack>, IVUserTrackRepository
    {
        public VUserTrackRepository(DimsContext context) : base(context)
        {
        }
    }
}