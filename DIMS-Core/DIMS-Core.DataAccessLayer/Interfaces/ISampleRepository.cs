using System.Linq;
using DIMS_Core.DataAccessLayer.Context;
using DIMS_Core.DataAccessLayer.Filters;

namespace DIMS_Core.DataAccessLayer.Interfaces
{
    public interface ISampleRepository : IRepository<Sample>
    {
        IQueryable<Sample> Search(SampleFilter filter);
    }
}