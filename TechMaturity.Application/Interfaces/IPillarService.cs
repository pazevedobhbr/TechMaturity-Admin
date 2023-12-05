using System;
using TechMaturity.Application.DTOs;

namespace TechMaturity.Application.Interfaces
{
    public interface IPillarService
    {
        Task<IEnumerable<PillarDTO>> GetPillars();

        Task<PillarDTO> GetById(int? id);

        Task Add(PillarDTO PillarDTO);

        Task Update(PillarDTO PillarDTO);

        Task Remove(int? id);

    }
}

