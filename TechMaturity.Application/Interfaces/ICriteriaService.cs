using System;
using TechMaturity.Application.DTOs;

namespace TechMaturity.Application.Interfaces
{
    public interface ICriteriaService
    {
        Task<IEnumerable<CriteriaDTO>> GetCriterias();

        Task<CriteriaDTO> GetById(int? id);

        Task Add(CriteriaDTO CriteriaDTO);

        Task Update(CriteriaDTO CriteriaDTO);

        Task Remove(int? id);

    }
}


