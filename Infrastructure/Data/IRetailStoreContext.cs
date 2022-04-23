using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public interface IRetailStoreContext
    {
        DbSet<CustomerType> CustomerTypes { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Invoice> Invoices { get; set; }
        DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        DbSet<ProductType> ProductTypes { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<DiscountDefinition> DiscountDefinitions { get; set; }

    }
}