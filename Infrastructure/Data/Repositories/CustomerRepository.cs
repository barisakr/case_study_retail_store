using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RetailStoreContext _context;
        public CustomerRepository(RetailStoreContext context)
        {
            _context = context;

        }
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<IReadOnlyList<Customer>> GetCustomersAsync()
        {
            return await _context.Customers
                .Include(x => x.CustomerType)
                .ToListAsync();
        }
    }
}