using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Errors;
using Domain.RepositoryInterfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        { 
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

               services.Configure<ApiBehaviorOptions>(
                options =>
                {
                    options.InvalidModelStateResponseFactory = actioncontex =>
                     {
                         var errors = actioncontex.ModelState
                            .Where(e => e.Value.Errors.Count > 0)
                            .SelectMany(x => x.Value.Errors)
                            .Select(x => x.ErrorMessage);

                         var response = new ApiValidation
                         {
                             Errors = errors
                         };

                         return new BadRequestObjectResult(response);

                     };
                }
            );
            return services;
        }
    }
}