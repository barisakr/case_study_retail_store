using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class InvoiceDetail : BaseEntity
    {
        public Invoice Invoice { get; set; }
        public int InvoiceId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal DiscountAmount { get; set; }

    }
}