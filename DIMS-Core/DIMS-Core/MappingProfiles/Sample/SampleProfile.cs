using AutoMapper;
using DIMS_Core.BusinessLayer.Models.Samples;
using DIMS_Core.Models.Sample;

namespace DIMS_Core.MappingProfiles.Sample
{
    public class SampleProfile : Profile
    {
        public SampleProfile()
        {
            CreateMap<SampleRequest, SampleRequestDto>();
            CreateMap<SampleResponseDto, SampleResponse>();
            CreateMap<SampleRequest, SampleResponse>();
        }
    }
}