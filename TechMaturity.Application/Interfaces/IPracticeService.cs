using System;
using TechMaturity.Application.DTOs;

namespace TechMaturity.Application.Interfaces
{
    public interface IPracticeService
    {
        Task<IEnumerable<PracticeDTO>> GetPractices();

        Task<PracticeDTO> GetById(int? id);

        Task Add(PracticeDTO PillarDTO);

        Task Update(PracticeDTO PillarDTO);

        Task Remove(int? id);

    }
}

