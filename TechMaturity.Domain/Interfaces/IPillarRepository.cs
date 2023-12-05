using System;
using TechMaturity.Domain.Entities;


namespace TechMaturity.Domain.Interfaces
{
    public interface IPillarRepository
    {
        Task<IEnumerable<Pillar>> GetPillarsAsync();
        Task<Category> GetByIcAsync(int? id);

        Task<Pillar> CreateAsync(Pillar pillar);
        Task<Pillar> UpdateAsync(Pillar Ppllar);
        Task<Pillar> RemoveAsync(Pillar pillar);
    }
}