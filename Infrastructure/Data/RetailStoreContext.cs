using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class RetailStoreContext : DbContext
    {
        public RetailStoreContext(DbContextOptions<RetailStoreContext> options) : base
            (options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
    }
}