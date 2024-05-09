using System;
using TechMaturity.Application.DTOs;

namespace TechMaturity.Application.Interfaces
{
    public interface ICapabilityService
    {
        Task<IEnumerable<CapabilityDTO>> GetCapabilities();

        Task<CapabilityDTO> GetById(int? id);

        Task Add(CapabilityDTO CapabilityDTO);

        Task Update(CapabilityDTO CapabilityDTO);

        Task Remove(int? id);

    }
}


