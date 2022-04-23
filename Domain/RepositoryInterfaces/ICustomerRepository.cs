using System.Collections.Generic;
using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface ICustomerRepository
    {
        Task<IReadOnlyList<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
    }
}