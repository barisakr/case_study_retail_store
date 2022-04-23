using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class CustomerType : BaseEntity
    {
        public string Name { get; set; }
        public string Definition { get; set; } 
        public DiscountDefinition DiscountDefinition { get; set; }
        public int DiscountDefinitionId { get; set; }
    }
}