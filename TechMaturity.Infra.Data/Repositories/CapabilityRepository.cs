using System;
using TechMaturity.Domain.Entities;
using TechMaturity.Domain.Interfaces;
using TechMaturity.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechMaturity.Infra.Data.Repositories
{
    public class CapabilityRepository :ICapabilityRepository
    {
        private ApplicationDbContext _CapabilityContext;
        public CapabilityRepository(ApplicationDbContext context)
        {
            _CapabilityContext = context;
        }

        public async Task<Capability> CreateAsync(Capability Capability)            
        {
            _CapabilityContext.Add(Capability);
            await _CapabilityContext.SaveChangesAsync();
            return Capability;
        }
        public async Task<IEnumerable<Capability>> GetCapabilitiesAsync()
        {
            return await _CapabilityContext.Capabilities.ToListAsync();

        }

        public async Task<Capability> GetByIcAsync(int? id)
        {
            return await _CapabilityContext.Capabilities.FindAsync(id);
        }

        public async Task<IEnumerable<Capability>> GetCapabilitysAsync()
        {
            return await _CapabilityContext.Capabilities.ToListAsync();
        }

        public async Task<Capability> RemoveAsync(Capability Capability)
        {
            _CapabilityContext.Remove(Capability);
            await _CapabilityContext.SaveChangesAsync();
            return Capability; 
        }

        public async Task<Capability> UpdateAsync(Capability Capability)
        {
            _CapabilityContext.Update(Capability);
            await _CapabilityContext.SaveChangesAsync();
            return Capability;
        }
    }
}


