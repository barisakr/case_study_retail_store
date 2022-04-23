using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class DiscountDefinition : BaseEntity
    {
        public string Name { get; set; }
        public int DiscountType { get; set; }
        public bool IsRatio { get; set; }
        public decimal Ratio { get; set; }
    }
}