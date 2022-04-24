using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Specifications
{
    public class ProductWithTypeSpecification : Specification<Product>
    {
        public ProductWithTypeSpecification()
        {
            AddInclude(x => x.ProductType);
        }

        public ProductWithTypeSpecification(int id)
        : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
        }

    }
}