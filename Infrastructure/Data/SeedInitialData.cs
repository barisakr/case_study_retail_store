using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class SeedInitialData
    {
        public static async Task SeedAsync(RetailStoreContext context, ILoggerFactory loggerfactory)
        {
            try
            {

                #region Discount Definitions 
                if (!context.DiscountDefinitions.Any())
                {
                    var discountData = File.ReadAllText("../Infrastructure/Data/SeedData/discountDefinition.json");
                    var definitions = JsonSerializer.Deserialize<List<DiscountDefinition>>(discountData);

                    foreach (var item in definitions)
                    {
                        context.DiscountDefinitions.Add(item);
                    }
                }
                #endregion Discount Definitions
                
                await context.SaveChangesAsync();

                #region Product Types
                if (!context.ProductTypes.Any())
                {
                    var productTypeData = File.ReadAllText("../Infrastructure/Data/SeedData/productType.json");
                    var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypeData);

                    foreach (var item in productTypes)
                    {
                        context.ProductTypes.Add(item);
                    }
                }
                #endregion Product Types

                #region Customer Types
                if (!context.CustomerTypes.Any())
                {
                    var customerTypeData = File.ReadAllText("../Infrastructure/Data/SeedData/customerType.json");
                    var customerTypes = JsonSerializer.Deserialize<List<CustomerType>>(customerTypeData);

                    foreach (var item in customerTypes)
                    {
                        context.CustomerTypes.Add(item);
                    }
                }
                #endregion Customer Types

                await context.SaveChangesAsync();

                #region Customers
                if (!context.Customers.Any())
                {
                    var customerData = File.ReadAllText("../Infrastructure/Data/SeedData/customer.json");
                    var customers = JsonSerializer.Deserialize<List<Customer>>(customerData);

                    foreach (var item in customers)
                    {
                        context.Customers.Add(item);
                    }
                }
                #endregion Customers

                #region Products
                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText("../Infrastructure/Data/SeedData/product.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }
                }
                #endregion Products

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerfactory.CreateLogger<SeedInitialData>();
                logger.LogError(ex.Message);
            }
        }
    }
}