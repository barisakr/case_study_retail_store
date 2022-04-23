using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public Customer Customer { get; set; }
        public int CustomerId { get; set; } 
        public string InvoiceNumber { get; set; }
        public decimal TotalAmount { get; set; } 
        public decimal TotalDiscountAmount { get; set; } 
        List<InvoiceDetail> InvoiceDetails {get; set; }
    }
}