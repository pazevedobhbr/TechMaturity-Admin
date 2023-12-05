using System;
using TechMaturity.Domain.Entities;
using TechMaturity.Domain.Interfaces;
using TechMaturity.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechMaturity.Infra.Data.Repositories
{
    public class PillarRepository :IPillarRepository
    {
        private ApplicationDbContext _PillarContext;
        public PillarRepository(ApplicationDbContext context)
        {
            _PillarContext = context;
        }

        public async Task<Pillar> CreateAsync(Pillar Pillar)            
        {
            _PillarContext.Add(Pillar);
            await _PillarContext.SaveChangesAsync();
            return Pillar;
        }

        public async Task<Pillar> GetByIcAsync(int? id)
        {
            return await _PillarContext.Pillars.FindAsync(id);
        }

        public async Task<IEnumerable<Pillar>> GetPillarsAsync()
        {
            return await _PillarContext.Pillars.ToListAsync();
        }

        public async Task<Pillar> RemoveAsync(Pillar Pillar)
        {
            _PillarContext.Remove(Pillar);
            await _PillarContext.SaveChangesAsync();
            return Pillar; 
        }

        public async Task<Pillar> UpdateAsync(Pillar Pillar)
        {
            _PillarContext.Update(Pillar);
            await _PillarContext.SaveChangesAsync();
            return Pillar;
        }
    }
}

