using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DataAccessLayer.Entities
{
    public class Attachment
    {
        public int? AttachmentsCode { get; set; }
        public int? Num { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string Ext { get; set; }
        public DateTime CreationDate { get; set; }
        public override string ToString()
        {
            var propertyStrings = from prop in GetType().GetProperties()
                select $"{prop.Name}={prop.GetValue(this)}";
            return string.Join(", ", propertyStrings);
            
        }

    }
}