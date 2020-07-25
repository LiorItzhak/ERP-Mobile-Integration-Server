using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DataAccessLayer.Entities.Documents
{
    public class DocReferencedEntity
    {
        public long DocKey { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DocType DocType { get; set; }
        
        public override string ToString()
        {
            var propertyStrings = from prop in GetType().GetProperties()
                select $"{prop.Name}={prop.GetValue(this)}";
            return string.Join(", ", propertyStrings);
            
        }
    }

    public enum DocType
    {
        Invoice,
        Order,
        Quotation,
        CreditNote,
        DeliveryNote,
        DownPaymentRequest,
        Receipt,
        Other
    }
}