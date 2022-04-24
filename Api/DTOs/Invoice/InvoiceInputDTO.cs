using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs.Invoice
{
    public class InvoiceInputDTO
    {
        [Required(ErrorMessage = "Invoice number is required")]
        [MaxLength(25)]
        public string InvoiceNumber { get; set; }

        [Required(ErrorMessage = "Invoice Details are required")]
        public List<InvoiceDetailInputDTO> InvoiceDetails { get; set; }
    }
}