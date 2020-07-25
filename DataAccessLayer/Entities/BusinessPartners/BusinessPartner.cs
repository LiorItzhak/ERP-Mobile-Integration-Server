using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DataAccessLayer.Entities.BusinessPartners
{
    public class BusinessPartner :Entity
    {
        public enum PartnerTypes
        {
            Customer,
            Lead,
            Supplier
        }

        public enum CardType
        {
            Private,
            Company,
            Employee
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Key { get; set; }

        public string Name { get; set; }

        public int? GroupSn { get; set; }
        // public CardGroup Group { get; set; }

        public CardType? Type { get; set; }

        public PartnerTypes? PartnerType { get; set; }
        public string FederalTaxId { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Cellular { get; set; }
        public string Email { get; set; }

        public string Fax { get; set; }

        //location's information
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public GeoLocation GeoLocation { get; set; }

        //finance
        [Column(TypeName = "decimal(10,3)")] public decimal? Balance { get; set; }
        [Column(TypeName = "decimal(10,3)")] public decimal? OrdersBalance { get; set; }
        [Column(TypeName = "decimal(10,3)")] public decimal? DeliveryNotesBalance { get; set; }
        [Column(TypeName = "decimal(10,3)")] public decimal? DiscountPercent { get; set; }
        public bool? IsVatFree { get; set; }

        public string Currency { get; set; }

        //other
        public string Comments { get; set; }
        public bool? IsActive { get; set; }
        public int? SalesmanCode { get; set; }

        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }




        public bool? IsFavorite { get; set; }
        
        public string IndicatorCode { get; set; }
        public int? IndustryCode { get; set; }
        
        public int? AttachmentsCode { get; set; }
        
    }


    public class CardGroup : Entity
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Sn { get; set; }

        public string Name { get; set; }
    }
    
    public class Indicator : Entity
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Code { get; set; }

        public string Name { get; set; }

    }
    public class Industry :Entity
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Code { get; set; }

        public string Name { get; set; }
    }
}