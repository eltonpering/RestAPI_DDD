using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("TB_ADDRESS")]
    public class Address 
    {        
        public int Id { get; set; }
     
        [MaxLength(255)]
        public string Street { get; set; }
        
        public int Number { get; set; }
        
        [MaxLength(10)]
        public int Zipcode { get; set; }
        
        [MaxLength(255)]
        public string City { get; set; }
        
        [MaxLength(255)]
        public string State { get; set; }
        
        [MaxLength(255)]
        public string Country { get; set; }
    }
}
