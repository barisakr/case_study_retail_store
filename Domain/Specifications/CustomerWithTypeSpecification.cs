using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Specifications
{
    public class CustomerWithTypeSpecification : Specification<Customer>
    {
        public CustomerWithTypeSpecification()
        {
            AddInclude(x => x.CustomerType);
            AddInclude(x => x.CustomerType.DiscountDefinition);
        }

        public CustomerWithTypeSpecification(int id)
        : base(x => x.Id == id)
        {
            AddInclude(x => x.CustomerType);
            AddInclude(x => x.CustomerType.DiscountDefinition);
        }
    }
}