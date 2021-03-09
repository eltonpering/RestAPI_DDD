﻿namespace ApplicationApp.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        
        public string Street { get; set; }

        public int Number { get; set; }
        
        public int Zipcode { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        public string Country { get; set; }
    }
}
