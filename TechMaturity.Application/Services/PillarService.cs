using System;
using AutoMapper;
using TechMaturity.Application.DTOs;
using TechMaturity.Application.Interfaces;
using TechMaturity.Domain.Entities;
using TechMaturity.Domain.Interfaces;

namespace TechMaturity.Application.Services
{
    public class PillarService : IPillarService
    {
        private IPillarRepository _PillarRepository;
        private readonly IMapper _mapper;

        public PillarService(IPillarRepository PillarRepository, IMapper mapper )
        {
            _PillarRepository = PillarRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PillarDTO>> GetPillars()
        {
            var pillarEntity = await _PillarRepository.GetPillarsAsync();
            return _mapper.Map<IEnumerable<PillarDTO>>(pillarEntity);
        }

        public async Task<PillarDTO> GetById(int? id)
        {
            var pillarEntity = await _PillarRepository.GetByIcAsync(id);
            return _mapper.Map<PillarDTO>(pillarEntity);
        }

        public async Task Add(PillarDTO PillarDTO)
        {
            var pillarEntity = _mapper.Map<Pillar>(PillarDTO);
            await _PillarRepository.CreateAsync(pillarEntity);

        }

        public async Task Update(PillarDTO PillarDTO)
        {
            var pillarEntity = _mapper.Map<Pillar>(PillarDTO);
            await _PillarRepository.UpdateAsync(pillarEntity);
        }

        public async Task Remove(int? id)
        {
            var pillarEntity = _PillarRepository.GetByIcAsync(id).Result;
            await _PillarRepository.RemoveAsync(pillarEntity);

        }
    }
}

