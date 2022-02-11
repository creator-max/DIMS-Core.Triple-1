using System.Linq;
using DIMS_Core.DataAccessLayer.Filters;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.DataAccessLayer.Interfaces
{
    public interface ISampleRepository : IRepository<Sample>
    {
        IQueryable<Sample> Search(SampleFilter filter);
    }
}