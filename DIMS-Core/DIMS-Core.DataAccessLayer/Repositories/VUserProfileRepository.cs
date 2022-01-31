using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class VUserProfileRepository : ReadOnlyRepository<VUserProfile>, IVUserProfileRepository
    {
        public VUserProfileRepository(DbContext context) : base(context)
        {
        }
    }
}
