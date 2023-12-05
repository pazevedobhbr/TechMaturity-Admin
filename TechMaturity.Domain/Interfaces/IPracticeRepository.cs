using System;
using TechMaturity.Domain.Entities;


namespace TechMaturity.Domain.Interfaces
{
    public interface IPracticeRepository
    {
        Task<IEnumerable<Practice>> GetPracticeAsync();
        Task<Practice> GetByIcAsync(int? id);

        Task<Practice> CreateAsync( Practice practice);
        Task<Practice> UpdateAsync( Practice practice);
        Task<Practice> RemoveAsync( Practice practice);
    }
}