using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("TB_CUSTOMER")]
    public class Customer
    {

        public Customer()
        {
            AddressCustomer = new Collection<AddressCustomer>();
            PhoneCustomer = new Collection<PhoneCustomer>();
        }

        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public ICollection<AddressCustomer> AddressCustomer { get; set; }

        public ICollection<PhoneCustomer> PhoneCustomer { get; set; }
    }
}
