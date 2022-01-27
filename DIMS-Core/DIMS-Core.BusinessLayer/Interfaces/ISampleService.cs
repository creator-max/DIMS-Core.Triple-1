using System.Collections.Generic;
using System.Threading.Tasks;
using DIMS_Core.BusinessLayer.Models.Samples;
using DIMS_Core.DataAccessLayer.Filters;

namespace DIMS_Core.BusinessLayer.Interfaces
{
    public interface ISampleService
    {
        Task<IReadOnlyCollection<SampleResponseDto>> Search(SampleFilter search);

        Task<SampleResponseDto> GetSample(int id);

        Task<SampleResponseDto> Create(SampleRequestDto requestDto);

        Task Delete(int id);

        Task<SampleResponseDto> Update(int id, SampleRequestDto requestDto);
    }
}