using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    [ComplexType]
    public class Address
    {
       
       // public string OwnerID { get; set; }
        public string ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Block { get; set; }
        public string Street { get; set; }
        public string NumAtStreet { get; set; }
        public string Apartment { get; set; }
        public string ZipCode { get; set; }

    }
}
