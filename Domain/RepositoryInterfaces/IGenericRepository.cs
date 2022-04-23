using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Base;
using Domain.Specifications;

namespace Domain.RepositoryInterfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id); 
        Task<IReadOnlyList<T>> GetAllAsync(); 
        Task<T> GetEntityWithSpecification(ISpecification<T> specification); 
        Task<IReadOnlyList<T>> ListAllAsync(ISpecification<T> specification);
        
    }
}