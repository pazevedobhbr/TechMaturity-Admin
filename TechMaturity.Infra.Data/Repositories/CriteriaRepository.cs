using System;
using TechMaturity.Domain.Entities;
using TechMaturity.Domain.Interfaces;
using TechMaturity.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechMaturity.Infra.Data.Repositories
{
    public class CriteriaRepository :ICriteriaRepository
    {
        private ApplicationDbContext _CriteriaContext;
        public CriteriaRepository(ApplicationDbContext context)
        {
            _CriteriaContext = context;
        }

        public async Task<Criteria> CreateAsync(Criteria Criteria)            
        {
            _CriteriaContext.Add(Criteria);
            await _CriteriaContext.SaveChangesAsync();
            return Criteria;
        }
        public async Task<IEnumerable<Criteria>> GetCriteriasAsync()
        {
            return await _CriteriaContext.Criterias.ToListAsync();

        }

        public async Task<Criteria> GetByIcAsync(int? id)
        {
            return await _CriteriaContext.Criterias.FindAsync(id);
        }


        public async Task<Criteria> RemoveAsync(Criteria Criteria)
        {
            _CriteriaContext.Remove(Criteria);
            await _CriteriaContext.SaveChangesAsync();
            return Criteria; 
        }

        public async Task<Criteria> UpdateAsync(Criteria Criteria)
        {
            _CriteriaContext.Update(Criteria);
            await _CriteriaContext.SaveChangesAsync();
            return Criteria;
        }
    }
}


