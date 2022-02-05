using DIMS_Core.DataAccessLayer.Context;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories.Base;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class VUserProfileRepository : ReadOnlyRepository<VUserProfile>, IVUserProfileRepository
    {
        public VUserProfileRepository(DimsContext context) : base(context)
        {
        }
    }
}
