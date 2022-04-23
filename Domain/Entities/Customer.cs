using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; } 
        public CustomerType CustomerType { get; set; } 
        public int CustomerTypeId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}