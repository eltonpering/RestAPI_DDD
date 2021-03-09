using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("TB_ADDRESS_CUSTOMER")]
    public class AddressCustomer
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public Address Address { get; set; }
        public int AddressId { get; set; }
    }
}
