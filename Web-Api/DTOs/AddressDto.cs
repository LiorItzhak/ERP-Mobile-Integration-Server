using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.DTOs
{
    
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AddressDto 
    {
        public string Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Block { get; set; }
        public string Street { get; set; }
        public string NumAtStreet { get; set; }
        public string Apartment { get; set; }
        public string ZipCode { get; set; }

       
    }
}
