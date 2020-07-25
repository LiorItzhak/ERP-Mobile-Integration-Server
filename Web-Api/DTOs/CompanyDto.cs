using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.DTOs
{
    public class CompanyDto
    {
        public int Code { get; set; }


        public string Name { get; set; }
        public string FederalTaxId { get; set; }
        public string Manager { get; set; }
        public AddressDto Address { get; set; }
        public string DefaultCurrency { get; set; }
        public decimal VatPercent { get; set; }
        public string WebSite { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }

        public string Fax { get; set; }
        public string Email { get; set; }
        public BankAccountDto BankAccount { get; set; }
    }

    public class BankDto
    {
        public string Code { get; set; }
        public string CountryCode { get; set; }

        public string Name { get; set; }
    }

    public class BankAccountDto
    {
        public BankDto Bank { get; set; }
        public string Branch { get; set; }
        public string Account { get; set; }

    }
}
