using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Base;
using Domain.RepositoryInterfaces;
using Domain.Specifications;
using Infrastructure.Data.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly RetailStoreContext _context;
        public GenericRepository(RetailStoreContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpecification(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.ApplyQuery(_context.Set<T>().AsQueryable(), specification);
        }

        public async Task<T> AddAsync(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entity)
        {
            await _context.Set<T>().AddRangeAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}