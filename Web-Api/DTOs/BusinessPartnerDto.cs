using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.DTOs
{
    public  class BusinessPartnerDto
    {
        public enum PartnerTypes {Customer,Lead,Supplier }
        public enum CardType { Private, Company, Employee }


        [JsonConverter(typeof(StringEnumConverter))]
        public CardType? Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PartnerTypes? PartnerType { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public int? GroupSn { get; set; }

        public string FederalTaxId { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Cellular { get; set; }
        public string Email { get; set; }

        public string Fax { get; set; }

        //location's information
        public AddressDto BillingAddress { get; set; }
        public AddressDto ShippingAddress { get; set; }
        public GeoLocationDto GeoLocation { get; set; }

        //finance
        public decimal? Balance { get; set; }
        public decimal? OrdersBalance { get; set; }
        public decimal? DeliveryNotesBalance { get; set; }
        public decimal? DiscountPercent { get; set; }
        public bool? IsVatFree { get; set; }
        public string Currency { get; set; }

        //other
        public string Comments { get; set; }

        public bool? IsActive { get; set; }
        public int? SalesmanCode { get; set; }

        public string CreationDateTime { get; set; }
        public string LastUpdateDateTime { get; set; }
        
        public bool? IsFavorite { get; set; }
        public string IndicatorCode { get; set; }
        public int? IndustryCode { get; set; }
        public int? AttachmentsCode { get; set; }


    }



    public class CardGroupDto
    {
        public int Sn { get; set; }
        public string Name { get; set; }
    }
    public class IndicatorDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class IndustryDto
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Code { get; set; }

        public string Name { get; set; }
    }
    public class GeoLocationDto
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Address { get; set; }
    }
}