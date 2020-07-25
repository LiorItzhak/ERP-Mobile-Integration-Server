using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class CompanyEntity
    {
        [Key]
        public int Code { get; set; }

        public string Name { get; set; }
        public string FederalTaxID { get; set; }
        public string Manager { get; set; }
        public Address Address { get; set; }
        public string DefaultCurrency { get; set; }
        [Column(TypeName = "decimal(3,2)")]
        public decimal VatPercent { get; set; }
        public string WebSite { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }

        public string Fax { get; set; }
        public string Email { get; set; }
        public BankAccountEntity BankAccount { get; set; }
    }

    public class BankEntity
    {
        [Key]
        public string Code { get; set; }
       // [Key]
        public string CountryCode { get; set; }

        public string Name { get; set; }
    }

    public class BankAccountEntity
    {
        public BankEntity Bank { get; set; }
        public string Branch { get; set; }
        public string Account { get; set; }

    }
}
