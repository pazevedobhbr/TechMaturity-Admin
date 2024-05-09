using System;
using TechMaturity.Domain.Entities;


namespace TechMaturity.Domain.Interfaces
{
    public interface ICapabilityRepository
    {
        Task<IEnumerable<Capability>> GetCapabilitiesAsync();
        Task<Capability> GetByIcAsync(int? id);

        Task<Capability> CreateAsync(Capability capability);
        Task<Capability> UpdateAsync(Capability capability);
        Task<Capability> RemoveAsync(Capability capability);
    }
}
