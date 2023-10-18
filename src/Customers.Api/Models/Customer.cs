namespace Customers.Api.Models
{
    public class Customer : Entity
    {
        public string? Name { get; set; }
        public IEnumerable<Address>? Address { get; set; }
        public short Age { get; set; }
    }
}