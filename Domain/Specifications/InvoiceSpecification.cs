using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Specifications
{
    public class InvoiceSpecification : Specification<Invoice>
    {
        public InvoiceSpecification()
        {
            AddInclude(x => x.Customer);
            AddInclude(x => x.Customer.CustomerType);
            AddInclude(x => x.Customer.CustomerType.DiscountDefinition);
        }
    }
}