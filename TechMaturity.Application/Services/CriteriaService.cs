using System;
using AutoMapper;
using TechMaturity.Application.DTOs;
using TechMaturity.Application.Interfaces;
using TechMaturity.Domain.Entities;
using TechMaturity.Domain.Interfaces;

namespace TechMaturity.Application.Services
{
    public class CriteriaService : ICriteriaService
    {
        private ICriteriaRepository _CriteriaRepository;
        private readonly IMapper _mapper;

        public CriteriaService(ICriteriaRepository CriteriarRepository, IMapper mapper )
        {
            _CriteriaRepository = CriteriarRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CriteriaDTO>> GetCriterias()
        {
            var CriteriaEntity = await _CriteriaRepository.GetCriteriasAsync();
            return _mapper.Map<IEnumerable<CriteriaDTO>>(CriteriaEntity);
        }

        public async Task<CriteriaDTO> GetById(int? id)
        {
            var CriteriaEntity = await _CriteriaRepository.GetByIcAsync(id);
            return _mapper.Map<CriteriaDTO>(CriteriaEntity);
        }

        public async Task Add(CriteriaDTO CriteriaDTO)
        {
            var CriteriaEntity = _mapper.Map<Criteria>(CriteriaDTO);
            await _CriteriaRepository.CreateAsync(CriteriaEntity);

        }

        public async Task Update(CriteriaDTO CriteriaDTO)
        {
            var CriteriaEntity = _mapper.Map<Criteria>(CriteriaDTO);
            await _CriteriaRepository.UpdateAsync(CriteriaEntity);
        }

        public async Task Remove(int? id)
        {
            var CriteriaEntity = _CriteriaRepository.GetByIcAsync(id).Result;
            await _CriteriaRepository.RemoveAsync(CriteriaEntity);

        }
    }
}

