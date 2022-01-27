using System;
using System.Threading.Tasks;

namespace DIMS_Core.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        ISampleRepository SampleRepository { get; }

        Task SaveChanges();
    }
}