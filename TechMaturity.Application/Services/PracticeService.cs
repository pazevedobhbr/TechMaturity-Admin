using System;
using AutoMapper;
using TechMaturity.Application.DTOs;
using TechMaturity.Application.Interfaces;
using TechMaturity.Domain.Entities;
using TechMaturity.Domain.Interfaces;

namespace TechMaturity.Application.Services
{
    public class PracticeService : IPracticeService
    {
        private IPracticeRepository _PracticeRepository;
        private readonly IMapper _mapper;

        public PracticeService(IPracticeRepository practiceepository, IMapper mapper )
        {
            _PracticeRepository = practiceepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PracticeDTO>> GetPractices()
        {
            var practiceEntity = await _PracticeRepository.GetPracticeAsync();
            return _mapper.Map<IEnumerable<PracticeDTO>>(practiceEntity);
        }

        public async Task<PracticeDTO> GetById(int? id)
        {
            var practiceEntity = await _PracticeRepository.GetByIcAsync(id);
            return _mapper.Map<PracticeDTO>(practiceEntity);
        }

        public async Task Add(PracticeDTO PracticeDTO)
        {
            var PracticeEntity = _mapper.Map<Practice>(PracticeDTO);
            await _PracticeRepository.CreateAsync(PracticeEntity);

        }

        public async Task Update(PracticeDTO PracticeDTO)
        {
            var PracticeEntity = _mapper.Map<Practice>(PracticeDTO);
            await _PracticeRepository.UpdateAsync(PracticeEntity);
        }

        public async Task Remove(int? id)
        {
            var practiceEntity = _PracticeRepository.GetByIcAsync(id).Result;
            await _PracticeRepository.RemoveAsync(practiceEntity);

        }
    }
}

