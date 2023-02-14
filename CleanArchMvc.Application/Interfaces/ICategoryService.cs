using System;
using CleanArchMvc.Application.DTOS;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();

        Task<CategoryDTO> GetById(int? id);

        Task Add(CategoryDTO categoryDTO);

        Task Update(CategoryDTO categoryDTO);

        Task AddRemove(int? id);

    }
}

