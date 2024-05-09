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
        private readonly ApplicationDbContext _CriteriaContext;
        public CriteriaRepository(ApplicationDbContext context)
        {
            _CriteriaContext = context;
        }

        public async Task<Criteria> CreateAsync(Criteria criteria)            
        {
            _CriteriaContext.Add(criteria);
            await _CriteriaContext.SaveChangesAsync();
            return criteria;
        }
        public async Task<IEnumerable<Criteria>> GetCriteriasAsync()
        {
            return await _CriteriaContext.Criteria.ToListAsync();

        }

        public async Task<Criteria> GetByIcAsync(int? id)
        {
            return await _CriteriaContext.Criteria.FindAsync(id);
        }


        public async Task<Criteria> RemoveAsync(Criteria criteria)
        {
            _CriteriaContext.Remove(criteria);
            await _CriteriaContext.SaveChangesAsync();
            return criteria; 
        }

        public async Task<Criteria> UpdateAsync(Criteria criteria)
        {
            _CriteriaContext.Update( criteria);
            await _CriteriaContext.SaveChangesAsync();
            return criteria;
        }
    }
}


