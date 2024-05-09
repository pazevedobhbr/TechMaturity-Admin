using System;
using AutoMapper;
using TechMaturity.Application.DTOs;
using TechMaturity.Application.Interfaces;
using TechMaturity.Domain.Entities;
using TechMaturity.Domain.Interfaces;

namespace TechMaturity.Application.Services
{
    public class CapabilityService : ICapabilityService
    {
        private ICapabilityRepository _CapabilityRepository;
        private readonly IMapper _mapper;

        public CapabilityService(ICapabilityRepository CapabilityrRepository, IMapper mapper )
        {
            _CapabilityRepository = CapabilityrRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CapabilityDTO>> GetCapabilities()
        {
            var CapabilityEntity = await _CapabilityRepository.GetCapabilitiesAsync();
            return _mapper.Map<IEnumerable<CapabilityDTO>>(CapabilityEntity);
        }

        public async Task<CapabilityDTO> GetById(int? id)
        {
            var CapabilityEntity = await _CapabilityRepository.GetByIcAsync(id);
            return _mapper.Map<CapabilityDTO>(CapabilityEntity);
        }

        public async Task Add(CapabilityDTO CapabilityDTO)
        {
            var CapabilityEntity = _mapper.Map<Capability>(CapabilityDTO);
            await _CapabilityRepository.CreateAsync(CapabilityEntity);

        }

        public async Task Update(CapabilityDTO CapabilityDTO)
        {
            var CapabilityEntity = _mapper.Map<Capability>(CapabilityDTO);
            await _CapabilityRepository.UpdateAsync(CapabilityEntity);
        }

        public async Task Remove(int? id)
        {
            var CapabilityEntity = _CapabilityRepository.GetByIcAsync(id).Result;
            await _CapabilityRepository.RemoveAsync(CapabilityEntity);

        }
    }
}

