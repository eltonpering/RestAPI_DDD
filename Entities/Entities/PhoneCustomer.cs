using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("TB_PHONE_CUSTOMER")]
    public class PhoneCustomer
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public string PhoneNumber { get; set; }
    }
}
