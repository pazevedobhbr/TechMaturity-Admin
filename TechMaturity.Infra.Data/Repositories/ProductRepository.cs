﻿using System;
using TechMaturity.Domain.Entities;
using TechMaturity.Domain.Interfaces;
using TechMaturity.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace TechMaturity.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _productContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIDAsync(int? id)
        {
            //return await _productContext.Products.FindAsync(id);
            //eager loading
            return await _productContext.Products.Include(c => c.Category)
                        .SingleOrDefaultAsync(p => p.Id == id);

        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productContext.Products.ToListAsync();
            
        }
    

        //public async Task<Product> GetProductCategoryAsync(int? id)
        //{
        //    //eager loading
        //    return await _productContext.Products.Include(c => c.Category)
        //                .SingleOrDefaultAsync(p => p.Id == id);
        //}

        public async Task<Product> RemoveAsync(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;

        }
    }
}

