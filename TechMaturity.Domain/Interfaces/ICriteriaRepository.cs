using System;
using TechMaturity.Domain.Entities;


namespace TechMaturity.Domain.Interfaces
{
    public interface ICriteriaRepository
    {
        Task<IEnumerable<Criteria>> GetCriteriasAsync();
        Task<Criteria> GetByIcAsync(int? id);

        Task<Criteria> CreateAsync(Criteria criteria);
        Task<Criteria> UpdateAsync(Criteria criteria);
        Task<Criteria> RemoveAsync(Criteria criteria);
    }
}
