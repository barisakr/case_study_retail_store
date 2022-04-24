using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs.Invoice
{
    public class InvoiceOutputDTO
    {
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
        public string DiscountType { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscountAmount { get; set; }
        public decimal TotalNetAmount { get; set; }
        // public List<InvoiceDetailOutputDTO> InvoiceDetails { get; set; } = new List<InvoiceDetailOutputDTO>();

    }
}