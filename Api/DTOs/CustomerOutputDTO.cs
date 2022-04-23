using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public class CustomerOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CustomerType { get; set; }
        public string DiscountType { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}