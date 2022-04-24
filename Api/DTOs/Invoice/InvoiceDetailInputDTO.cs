using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOs.Product;

namespace Api.DTOs.Invoice
{
    public class InvoiceDetailInputDTO
    {
        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Quantity is need to be positive")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Product is required")]
        public ProductInputDTO Product { get; set; }
    }
}