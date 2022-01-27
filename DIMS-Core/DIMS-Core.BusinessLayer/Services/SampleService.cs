using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dawn;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models.Samples;
using DIMS_Core.DataAccessLayer.Context;
using DIMS_Core.DataAccessLayer.Filters;
using DIMS_Core.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.BusinessLayer.Services
{
    internal class SampleService : ISampleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SampleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<SampleResponseDto>> Search(SampleFilter search)
        {
            var query = _unitOfWork.SampleRepository.Search(search);
            var mappedQuery = _mapper.ProjectTo<SampleResponseDto>(query);

            return await mappedQuery.ToArrayAsync();
        }

        public async Task<SampleResponseDto> GetSample(int id)
        {
            Guard.Argument(id)
                 .GreaterThan(0);

            var entity = await _unitOfWork.SampleRepository.GetById(id);
            var model = _mapper.Map<SampleResponseDto>(entity);

            return model;
        }

        public async Task<SampleResponseDto> Create(SampleRequestDto requestDto)
        {
            Guard.Argument(requestDto)
                 .NotNull();

            var entity = _mapper.Map<Sample>(requestDto);

            await _unitOfWork.SampleRepository.Create(entity);
            await _unitOfWork.SaveChanges();

            return _mapper.Map<SampleResponseDto>(entity);
        }

        public async Task<SampleResponseDto> Update(int id, SampleRequestDto requestDto)
        {
            Guard.Argument(requestDto)
                 .NotNull();
            Guard.Argument(id)
                 .GreaterThan(0);

            var entity = await _unitOfWork.SampleRepository.GetById(id);
            Guard.Argument(entity)
                 .NotNull();

            var mappedEntity = _mapper.Map(requestDto, entity);

            _unitOfWork.SampleRepository.Update(mappedEntity);

            await _unitOfWork.SaveChanges();

            return _mapper.Map<SampleResponseDto>(entity);
        }

        public async Task Delete(int id)
        {
            Guard.Argument(id)
                 .GreaterThan(0);

            await _unitOfWork.SampleRepository.Delete(id);
            await _unitOfWork.SaveChanges();
        }
    }
}