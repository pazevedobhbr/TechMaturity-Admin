using System;
using TechMaturity.Domain.Entities;
using TechMaturity.Domain.Interfaces;
using TechMaturity.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechMaturity.Infra.Data.Repositories
{
    public class PracticeRepository : IPracticeRepository
    {
        private ApplicationDbContext _PracticeContext;
        public PracticeRepository(ApplicationDbContext context)
        {
            _PracticeContext = context;
        }

        public async Task<Practice> CreateAsync(Practice Practice)
        {
            _PracticeContext.Add(Practice);
            await _PracticeContext.SaveChangesAsync();
            return Practice;
        }

        public async Task<Practice> GetByIcAsync(int? id)
        {
            return await _PracticeContext.Practices.FindAsync(id);
        }

        public async Task<IEnumerable<Practice>> GetPracticeAsync()
        {
            return await _PracticeContext.Practices.ToListAsync();
        }

        public async Task<Practice> RemoveAsync(Practice Practice)
        {
            _PracticeContext.Remove(Practice);
            await _PracticeContext.SaveChangesAsync();
            return Practice;
        }

        public async Task<Practice> UpdateAsync(Practice Practice)
        {
            _PracticeContext.Update(Practice);
            await _PracticeContext.SaveChangesAsync();
            return Practice;
        }
    }
}

